using Core.Dto.Request;
using Core.Dto.Response;
using Core.Entities;
using Core.Helper;
using Core.Identity;
using Core.ImagesHandler;
using Core.Interfaces;
using Core.Jwt;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Core.ImagesHandler.ImagesRepository;

namespace Infrastructure.Repo
{
    public class ProudectRepo : IProudect
    {

        private readonly AppDbContext _Context;
        private readonly IRepositoryImages _repositoryImages;
        private readonly JwtTokenData _jwtTokenData;

        public ProudectRepo(AppDbContext context, IRepositoryImages repositoryImages,ITokenDecoder token)
        {
            _Context = context;
            _repositoryImages = repositoryImages;
            _jwtTokenData=token.GetTokenData();
        }

        public async Task<ApiResponse> ActiveProudectByID(Guid ProudectId)
        {
            var Proudect=  _Context.Proudects.FirstOrDefault(Pr=>Pr.Id==ProudectId);
            if (Proudect != null)
            {
                Proudect.ActiveProudect = true;
                 _Context.SaveChanges();
                return new ApiResponse()
                {
                    Message = "The Proudect now Is Active",
                 
                    Status = 200,
                    isSuccess = true

                };

            }
            return new ApiResponse()
            {
                Message = "The Proudect Is not Active",

                Status = 200,
                isSuccess = false

            };
        }

        public async Task< ApiResponse> CreateProudect(ProudectRequest proudect)
        {
            var transaction = _Context.Database.BeginTransaction();

            {
                try
                {
                    var imageProudect = _repositoryImages.AddImage(proudect.ProudectImage, (int)ImageTypes.Proudect);
                    var ImageDbProudect = new Image() { Id = imageProudect.ImageId, Path = imageProudect.Fullpath ,Type= (int)ImageTypes.Proudect };
                    var imageProudectLicence = _repositoryImages.AddImage(proudect.ProudectLicence, (int)ImageTypes.ProudectLicence);
                    var ImageDbLicence = new Image() { Id = imageProudectLicence.ImageId, Path = imageProudectLicence.Fullpath,Type= (int)ImageTypes.ProudectLicence };
                    _Context.Images.AddRange(ImageDbProudect,ImageDbLicence);
                    
                    await _Context.SaveChangesAsync();

                    var ProudectDb = new Proudect()
                    {
                        Id = Guid.NewGuid(),
                        NameInArabic = proudect.NameInArabic,
                        NameInEnglish = proudect.NameInEnglish,
                        NumberOfRetailUnits = proudect.NumberOfRetailUnits,
                        NumberOfTablets = proudect.NumberOfTablets,
                        CompanyNameInEnglish = proudect.CompanyNameInEnglish,
                        TypeOfMedicationId = proudect.TypeOfMedicationId,
                        FactoryNameInEnglish = proudect.FactoryNameInEnglish,
                        WayMedicineUsedId = proudect.WayMedicineUsedId,
                        ActiveSubstances = proudect.ActiveSubstances,
                        Discription = proudect.Discription,
                        DiscriminationId = proudect.DiscriminationId,
                        InternationalBarcode = proudect.InternationalBarcode,
                        TaxRegistrationAuthority = proudect.TaxRegistrationAuthority,
                        PharmaceuticalFormId = proudect.PharmaceuticalFormId,
                        pharmacology = proudect.pharmacology,
                        Price = proudect.Price,
                        AgentDiscount= proudect.AgentDiscount,
                        Priority = (int)Enums.ProudectPriority.basic,
                        AgentRequest = proudect.AgentRequest,
                        TaxRegistrationNumber = proudect.TaxRegistrationNumber,
                        TaxRegistrationYear = proudect.TaxRegistrationYear,
                        AppUserId = _jwtTokenData.UserId,
                        ActiveProudect=false,
                        Discount= proudect.Discount,
                        PricingSettingsId=_Context.PricingSettings?.FirstOrDefault(pay=>pay.Type==_jwtTokenData.Role)?.Id??null

                    };
                    
                   await _Context.Proudects.AddAsync(ProudectDb);

                   await _Context.SaveChangesAsync();
                    ImageDbProudect.Proudectid = ProudectDb.Id;
                    ImageDbProudect.AppUseriD = _jwtTokenData.UserId;
                    ImageDbLicence.Proudectid = ProudectDb.Id;
                    ImageDbLicence.AppUseriD = _jwtTokenData.UserId;
                    await _Context.SaveChangesAsync();

                    AddGeographicalDistributionRang(proudect.GeographicalDistributionRanges, ProudectDb.Id);

                    await transaction.CommitAsync();
                }
                catch (Exception ex) {
                
               await transaction.RollbackAsync();
                    return new ApiResponse() { isSuccess = false, Status =200 , Message = "The Proudect not Created" };
                }


                return new ApiResponse() { isSuccess= true,Status=200,Message="The Proudect Created"};

                throw new NotImplementedException();
            }
        }

        public async Task<ApiResponse> DeleteProudectByID(Guid ProudectId)

        {
            try
            {
                var Proudect = await _Context.Proudects.Include(Pro=>Pro.Images)
                    .Include(Pro=>Pro.GeographicalDistributionRanges)
                    
               
                    .FirstOrDefaultAsync(pr => pr.Id == ProudectId);
                if (Proudect != null)
                {


                    _Context.RemoveRange(Proudect.GeographicalDistributionRanges);
                        _Context.RemoveRange(Proudect.Images);
                    
              
                    _Context.Remove(Proudect);
                    _Context.SaveChanges();
                }
                return new ApiResponse(){
                   isSuccess= true, 
                   Status=200,
                   Message="This Proudect Deleted"
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse()
                {
                    isSuccess = false,
                    Status = 200,
                    Message = "This Proudect not Deleted"
                };
            }
        }

        public async Task<ApiResponse<List<AllProudectsResponse>>> GetAllActiveProudects(int PageNumber=1, int Count=10)
        {
            if (PageNumber > 0 && Count > 0)
            {
                int AlreadyseenCount = (PageNumber - 1) * Count;
                var Proudects = await _Context.Proudects
    .Include(pr => pr.AppUser)

    .Include(pr => pr.Images)

    .Where(pr => pr.ActiveProudect == true)
     .Skip(AlreadyseenCount)
                    .Take(Count)
    .OrderByDescending(pr => pr.Priority )
    .ToListAsync();

                if (Proudects.Any())
                {

                    List<AllProudectsResponse> ProudectsRes = new List<AllProudectsResponse>();
                    foreach (var Proudect in Proudects)
                    {
                        ProudectsRes.Add(new AllProudectsResponse()
                        {
                            Id = Proudect.Id,
                            NameInArabic = Proudect.NameInArabic,
                            NameInEnglish = Proudect.NameInEnglish,
                            ActiveSubstances = Proudect.ActiveSubstances,
                            AppUser = Proudect.AppUser,
                            CompanyNameInEnglish = Proudect.CompanyNameInEnglish,
                            Discount = Proudect.Discount,
                            Discription = Proudect.Discription,
                            FactoryNameInEnglish = Proudect.FactoryNameInEnglish,
                            Price = Proudect.Price,
                            AgentRequest = Proudect.AgentRequest,
                            ProudectImage = ImagesUtilities.GetImage(Proudect.Images.FirstOrDefault(img => img.Type == (int)ImageTypes.Proudect).Path),

                        });
                    }




                    return new ApiResponse<List<AllProudectsResponse>>()
                    {
                        Message = "There are our Proudects",
                        Data = ProudectsRes,
                        Status = 200,
                        isSuccess = true

                    };

                }
                return new ApiResponse<List<AllProudectsResponse>>()
                {
                    Message = "We don't have any Proudects",
                    Data = null,
                    Status = 200,
                    isSuccess = false

                };
            }

            return new ApiResponse<List<AllProudectsResponse>>()
            {
                Message = "We don't have any Proudects",
                Data = null,
                Status = 200,
                isSuccess = false

            };


        }

        public async Task<ApiResponse<List<AllProudectsResponse>>> GetAllNonActiveProudects(int PageNumber = 1, int Count = 10)
        {
            if (PageNumber > 0 && Count > 0)
            {
                int AlreadyseenCount = (PageNumber - 1) * Count;
                var Proudects = await _Context.Proudects
   .Include(pr => pr.AppUser)
   .Include(pr => pr.Discrimination)
   .Include(pr => pr.PharmaceuticalForm)
   .Include(pr => pr.GeographicalDistributionRanges)
   .Include(pr => pr.Images)
   .Include(pr => pr.PharmaceuticalForm)
   .Include(pr => pr.TypeOfMedication)
   .Include(pr => pr.WayMedicineUsed)
   .Where(pr => pr.ActiveProudect == false)
    .Skip(AlreadyseenCount)
                    .Take(Count)
   .OrderByDescending(pr => pr.Priority)
   .ToListAsync();

                if (Proudects.Any())
                {

                    List<AllProudectsResponse> ProudectsRes = new List<AllProudectsResponse>();
                    foreach (var Proudect in Proudects)
                    {
                        ProudectsRes.Add(new AllProudectsResponse()
                        {
                            Id = Proudect.Id,
                            NameInArabic = Proudect.NameInArabic,
                            NameInEnglish = Proudect.NameInEnglish,
                            Discount = Proudect.Discount,
                            ActiveSubstances = Proudect.ActiveSubstances,
                            AppUser = Proudect.AppUser,
                            CompanyNameInEnglish = Proudect.CompanyNameInEnglish,
                            Discription = Proudect.Discription,
                            FactoryNameInEnglish = Proudect.FactoryNameInEnglish,
                            Price = Proudect.Price,
                            AgentRequest = Proudect.AgentRequest,
                            ProudectImage = ImagesUtilities.GetImage(Proudect.Images.FirstOrDefault(img => img.Type == (int)ImageTypes.Proudect).Path),

                        });
                    }




                    return new ApiResponse<List<AllProudectsResponse>>()
                    {
                        Message = "There are our Proudects",
                        Data = ProudectsRes,
                        Status = 200,
                        isSuccess = true
                    };
                }
                return new ApiResponse<List<AllProudectsResponse>>()
                {
                    Message = "We don't have any Proudects",
                    Data = new List<AllProudectsResponse>(),
                    Status = 200,
                    isSuccess = false
                };
            }
            return new ApiResponse<List<AllProudectsResponse>>()
            {
                Message = "We don't have any Proudects",
                Data = new List<AllProudectsResponse>(),
                Status = 200,
                isSuccess = false
            };

        }

   

        public async Task<ApiResponse<ProudectResponse>> GetProudectByID(Guid ProudectId)
        {

            var Proudect =  _Context.Proudects
    .Include(pr => pr.AppUser)
    .Include(pr => pr.Discrimination)
    .Include(pr => pr.PharmaceuticalForm)
    .Include(pr => pr.GeographicalDistributionRanges).ThenInclude(GeoReg=>GeoReg.Governorate)
    .Include(pr => pr.Images)
    .Include(pr => pr.PharmaceuticalForm)
    .Include(pr => pr.TypeOfMedication)
    .Include(pr => pr.WayMedicineUsed)
    
     .FirstOrDefault(pr => pr.Id == ProudectId);


            if(Proudect!=null)
            {
                return new ApiResponse<ProudectResponse>()
                {
                    Message = "There are our Proudects",
                    Data = new ProudectResponse()
                    {
                        Id= Proudect.Id,
                        NameInArabic = Proudect.NameInArabic,
                        NameInEnglish = Proudect.NameInEnglish,
                        NumberOfRetailUnits = Proudect.NumberOfRetailUnits,
                        NumberOfTablets = Proudect.NumberOfTablets,
                        TypeOfMedicationId = Proudect.TypeOfMedication.Id,
                        TypeOfMedicationName=Proudect.TypeOfMedication.Name,
                        ActiveSubstances = Proudect.ActiveSubstances,
                        AgentRequest = Proudect.AgentRequest,
                        WayMedicineUsedId = Proudect.WayMedicineUsed.Id,
                        WayMedicineUsedName=Proudect.WayMedicineUsed.Name,
                        AppUserId = Proudect.AppUser.Id,
                        AppUserNameInArabic=Proudect.AppUser.NameInArabic,
                        AppUserNameInEnglish=Proudect.AppUser.NameInEnglish,
                        TaxRegistrationAuthority = Proudect.TaxRegistrationAuthority,
                        CompanyNameInEnglish = Proudect.CompanyNameInEnglish,
                        DiscriminationId = Proudect.Discrimination.Id,
                        DiscriminationName=Proudect.Discrimination.Name,
                        Discription = Proudect.Discription,
                        FactoryNameInEnglish = Proudect.FactoryNameInEnglish,
                        GeographicalDistributionRanges = Proudect.GeographicalDistributionRanges.Select(item=>
                        new MapLocationForProudect()
                        {
                            GovernorateId=item.GovernorateId!=null? item.GovernorateId:Guid.Empty,
                           GovernorateNameInEnglish=item.Governorate?.NameInEnglish!=null? item.Governorate.NameInEnglish:" ",
                           GovernorateNameInArabic=item.Governorate?.NameInArabic!=null? item.Governorate.NameInArabic:" ",
                            City=item.City!=null? item.City:" ",
                            station=item.station!=null? item.station:" "

                        }).ToList(),
                        InternationalBarcode = Proudect.InternationalBarcode,
                        PharmaceuticalFormId = Proudect.PharmaceuticalForm.Id,
                        PharmaceuticalFormName= Proudect.PharmaceuticalForm.Name,
                        pharmacology = Proudect.pharmacology,
                        Price = Proudect.Price,
                        ProudectImage = ImagesUtilities.GetImage(Proudect.Images.FirstOrDefault(img => img.Type == (int)ImageTypes.Proudect).Path),
                        ProudectLicence = ImagesUtilities.GetImage(Proudect.Images.FirstOrDefault(img => img.Type == (int)ImageTypes.ProudectLicence).Path),
                        TaxRegistrationNumber = Proudect.TaxRegistrationNumber,
                        TaxRegistrationYear = Proudect.TaxRegistrationYear,
                    },
                    Status = 200,
                    isSuccess = true

                };

               


            }

            return new ApiResponse<ProudectResponse>()
            {
                Message = "We don't have this Proudect",
                Data = null,
                Status = 200,
                isSuccess = false

            };


            throw new NotImplementedException();
        }

        public async Task<ApiResponse<List<AllProudectsResponse>>> GetProudectsByLocation(int PageNumber = 1, int Count = 10)
        {

            if (PageNumber > 0 && Count > 0)
            {
                int AlreadyseenCount = (PageNumber - 1) * Count;
                var UserLocations = _jwtTokenData.Governorates;


                if (!UserLocations.Any() || UserLocations == null)
                {
                    return new ApiResponse<List<AllProudectsResponse>>()
                    {
                        Message = "We don't have any Proudects",
                        Data = new List<AllProudectsResponse>() { },
                        Status = 200,
                        isSuccess = false
                    };

                }
                //  var CrossLocattion = await _Context.Proudects.Include(x => x.GeographicalDistributionRanges).Where(govId => govId.GeographicalDistributionRanges.Select(geo => geo.GovernorateId).Except(Userlocations).Any()).ToListAsync();
                //.Include(x => x.GeographicalDistributionRanges).Select(govId => govId.GeographicalDistributionRanges.Select(geo => geo.GovernorateId).Except(Userlocations))
                var CrossLocationProducts = await _Context.Proudects
            .Include(pr => pr.AppUser)
            .Include(pr => pr.Images)
            .Include(pr => pr.PharmaceuticalForm)
            .Include(pr => pr.TypeOfMedication)
            .Include(pr => pr.WayMedicineUsed)
            .Include(pr => pr.GeographicalDistributionRanges)
            .Where(pr => pr.GeographicalDistributionRanges
               .Any(geo => UserLocations.Contains(geo.GovernorateId)))
            .Where(pr => pr.ActiveProudect)
             .Skip(AlreadyseenCount)
                    .Take(Count)
            .OrderByDescending(pr => pr.Priority)
            .ToListAsync();


                if (CrossLocationProducts.Any())
                {

                    List<AllProudectsResponse> ProudectsRes = new List<AllProudectsResponse>();
                    foreach (var Proudect in CrossLocationProducts)
                    {
                        ProudectsRes.Add(new AllProudectsResponse()
                        {
                            Id = Proudect.Id,
                            NameInArabic = Proudect.NameInArabic,
                            NameInEnglish = Proudect.NameInEnglish,
                            Discount = Proudect.Discount,
                            ActiveSubstances = Proudect.ActiveSubstances,
                            AppUser = Proudect.AppUser,
                            CompanyNameInEnglish = Proudect.CompanyNameInEnglish,
                            Discription = Proudect.Discription,
                            FactoryNameInEnglish = Proudect.FactoryNameInEnglish,
                            Price = Proudect.Price,
                            AgentRequest = Proudect.AgentRequest,
                            ProudectImage = ImagesUtilities.GetImage(Proudect.Images.FirstOrDefault(img => img.Type == (int)ImageTypes.Proudect).Path),

                        });
                    }




                    return new ApiResponse<List<AllProudectsResponse>>()
                    {
                        Message = "There are our Proudects",
                        Data = ProudectsRes,
                        Status = 200,
                        isSuccess = true
                    };

                }



                return new ApiResponse<List<AllProudectsResponse>>()
                {
                    Message = "We don't have any Proudects",
                    Data = new List<AllProudectsResponse>() { },
                    Status = 200,
                    isSuccess = false
                };
            }
            return new ApiResponse<List<AllProudectsResponse>>()
            {
                Message = "We don't have any Proudects",
                Data = new List<AllProudectsResponse>() { },
                Status = 200,
                isSuccess = false
            };

        }

        public async Task<ApiResponse> UnActiveProudectByID(Guid ProudectId)
        {
            var Proudect =  _Context.Proudects.FirstOrDefault(Pr => Pr.Id == ProudectId);
            if (Proudect != null)
            {
                Proudect.ActiveProudect = false;
                _Context.SaveChanges();
                return new ApiResponse()
                {
                    Message = "The Proudect now Is UnActive",

                    Status = 200,
                    isSuccess = true

                };

            }
            return new ApiResponse()
            {
                Message = "The Proudect Is Active",

                Status = 200,
                isSuccess = false

            };
        }

        public async Task<ApiResponse<List<AllProudectsResponse>>> GetProudectsByEnglishName(string ProudectEnglishName)
        {
            var Proudects = await _Context.Proudects
    .Include(pr => pr.AppUser)

    .Include(pr => pr.Images)

    .Where(pr => pr.ActiveProudect == true && pr.NameInEnglish.StartsWith(ProudectEnglishName))
    .OrderByDescending(pr => pr.Priority)
    .ToListAsync();

            if (Proudects.Any())
            {

                List<AllProudectsResponse> ProudectsRes = new List<AllProudectsResponse>();
                foreach (var Proudect in Proudects)
                {
                    ProudectsRes.Add(new AllProudectsResponse()
                    {
                        Id = Proudect.Id,
                        NameInArabic = Proudect.NameInArabic,
                        NameInEnglish = Proudect.NameInEnglish,
                        ActiveSubstances = Proudect.ActiveSubstances,
                        AppUser = Proudect.AppUser,
                        CompanyNameInEnglish = Proudect.CompanyNameInEnglish,
                        Discount = Proudect.Discount,
                        Discription = Proudect.Discription,
                        FactoryNameInEnglish = Proudect.FactoryNameInEnglish,
                        Price = Proudect.Price,
                        AgentRequest = Proudect.AgentRequest,
                        ProudectImage = ImagesUtilities.GetImage(Proudect.Images.FirstOrDefault(img => img.Type == (int)ImageTypes.Proudect).Path),

                    });
                }




                return new ApiResponse<List<AllProudectsResponse>>()
                {
                    Message = "There are our Proudects",
                    Data = ProudectsRes,
                    Status = 200,
                    isSuccess = true

                };
            }
            return new ApiResponse<List<AllProudectsResponse>>()
            {
                Message = "We don't have any Proudects",
                Data = null,
                Status = 200,
                isSuccess = false

            };



        }
        
        public async Task<ApiResponse<List<AllProudectsResponse>>> GetProudectsByArabicName(string ProudectArabicName)
        {
            var Proudects = await _Context.Proudects
    .Include(pr => pr.AppUser)

    .Include(pr => pr.Images)

    .Where(pr => pr.ActiveProudect == true && pr.NameInArabic.StartsWith(ProudectArabicName))
    .OrderByDescending(pr => pr.Priority)
    .ToListAsync();

            if (Proudects.Any())
            {

                List<AllProudectsResponse> ProudectsRes = new List<AllProudectsResponse>();
                foreach (var Proudect in Proudects)
                {
                    ProudectsRes.Add(new AllProudectsResponse()
                    {
                        Id = Proudect.Id,
                        NameInArabic = Proudect.NameInArabic,
                        NameInEnglish = Proudect.NameInEnglish,
                        ActiveSubstances = Proudect.ActiveSubstances,
                        AppUser = Proudect.AppUser,
                        CompanyNameInEnglish = Proudect.CompanyNameInEnglish,
                        Discount = Proudect.Discount,
                        Discription = Proudect.Discription,
                        FactoryNameInEnglish = Proudect.FactoryNameInEnglish,
                        Price = Proudect.Price,
                        AgentRequest = Proudect.AgentRequest,
                        ProudectImage = ImagesUtilities.GetImage(Proudect.Images.FirstOrDefault(img => img.Type == (int)ImageTypes.Proudect).Path),

                    });
                }




                return new ApiResponse<List<AllProudectsResponse>>()
                {
                    Message = "There are our Proudects",
                    Data = ProudectsRes,
                    Status = 200,
                    isSuccess = true

                };
            }
            return new ApiResponse<List<AllProudectsResponse>>()
            {
                Message = "We don't have any Proudects",
                Data = null,
                Status = 200,
                isSuccess = false

            };



        }
        public async Task<ApiResponse<ProudectResponse>> UpdateProudect(Guid ProudectId, ProudectRequestUpdate UpdateRequest)
        {


            try
            {
                if (UpdateRequest.ProudectImage != null)
                {
                    var imageProudect = _repositoryImages.AddImage(UpdateRequest.ProudectImage, (int)ImageTypes.Proudect);


                    var ProudectImage = _Context.Images.FirstOrDefault(img=>img.Proudectid== ProudectId && img.Type==(int)ImageTypes.Proudect);

                    ProudectImage.Path = imageProudect.Fullpath;
                }
                            



                var Proudect =_Context.Proudects
    .Include(pr => pr.AppUser)
    .Include(pr => pr.Discrimination)
    .Include(pr => pr.PharmaceuticalForm)
    .Include(pr => pr.GeographicalDistributionRanges).ThenInclude(GeoRq=> GeoRq.Governorate)
    .Include(pr => pr.Images)
    .Include(pr => pr.PharmaceuticalForm)
    .Include(pr => pr.TypeOfMedication)
    .Include(pr => pr.WayMedicineUsed)

     .FirstOrDefault(pr => pr.Id == ProudectId);


                if (Proudect != null)
                {

                    Proudect.NameInArabic = UpdateRequest.NameInArabic!=null? UpdateRequest.NameInArabic : Proudect.NameInArabic;
                    Proudect.NameInEnglish = UpdateRequest.NameInEnglish != null ? UpdateRequest.NameInEnglish : Proudect.NameInEnglish;
                    Proudect.InternationalBarcode = UpdateRequest.InternationalBarcode != null ? UpdateRequest.InternationalBarcode : Proudect.InternationalBarcode;
                    Proudect.DiscriminationId = (Guid)(UpdateRequest.DiscriminationId != null ? UpdateRequest.DiscriminationId : Proudect.DiscriminationId);
                    Proudect.Discription = UpdateRequest.Discription != null ? UpdateRequest.Discription : Proudect.Discription;
                    Proudect.Price = (decimal)(UpdateRequest.Price != null ? UpdateRequest.Price : Proudect.Price);
                    Proudect.CompanyNameInEnglish = UpdateRequest.CompanyNameInEnglish != null ? UpdateRequest.CompanyNameInEnglish : Proudect.CompanyNameInEnglish;
                    Proudect.FactoryNameInEnglish = UpdateRequest.FactoryNameInEnglish != null ? UpdateRequest.FactoryNameInEnglish : Proudect.FactoryNameInEnglish;
                    Proudect.pharmacology = UpdateRequest.pharmacology != null ? UpdateRequest.pharmacology : Proudect.pharmacology;
                    Proudect.AgentRequest = (bool)(UpdateRequest.AgentRequest != null ? UpdateRequest.AgentRequest : Proudect.AgentRequest);
                    Proudect.PharmaceuticalFormId = (Guid)(UpdateRequest.PharmaceuticalFormId != null ? UpdateRequest.PharmaceuticalFormId : Proudect.PharmaceuticalFormId);

                    Proudect.DiscriminationId = (Guid)(UpdateRequest.DiscriminationId != null ? UpdateRequest.DiscriminationId : Proudect.DiscriminationId);

                    Proudect.WayMedicineUsedId = (Guid)(UpdateRequest.WayMedicineUsedId != null ? UpdateRequest.WayMedicineUsedId : Proudect.WayMedicineUsedId);

                    Proudect.TypeOfMedicationId = (Guid)(UpdateRequest.TypeOfMedicationId != null ? UpdateRequest.TypeOfMedicationId : Proudect.TypeOfMedicationId);

                    Proudect.Discount = UpdateRequest.Discount;



                }

                _Context.SaveChanges();

                return new ApiResponse<ProudectResponse>() {
                Data=new ProudectResponse() {
                    Id = Proudect.Id,
                    NameInArabic = Proudect.NameInArabic,
                    NameInEnglish = Proudect.NameInEnglish,
                    NumberOfRetailUnits = Proudect.NumberOfRetailUnits,
                    NumberOfTablets = Proudect.NumberOfTablets,
                    TypeOfMedicationId = Proudect.TypeOfMedication.Id,
                    TypeOfMedicationName = Proudect.TypeOfMedication.Name,
                    ActiveSubstances = Proudect.ActiveSubstances,
                    AgentRequest = Proudect.AgentRequest,
                    WayMedicineUsedId = Proudect.WayMedicineUsed.Id,
                    WayMedicineUsedName = Proudect.WayMedicineUsed.Name,
                    AppUserId = Proudect.AppUser.Id,
                    AppUserNameInArabic = Proudect.AppUser.NameInArabic,
                    AppUserNameInEnglish = Proudect.AppUser.NameInEnglish,
                    TaxRegistrationAuthority = Proudect.TaxRegistrationAuthority,
                    CompanyNameInEnglish = Proudect.CompanyNameInEnglish,
                    DiscriminationId = Proudect.Discrimination.Id,
                    DiscriminationName = Proudect.Discrimination.Name,
                    Discription = Proudect.Discription,
                    FactoryNameInEnglish = Proudect.FactoryNameInEnglish,
                    GeographicalDistributionRanges = Proudect.GeographicalDistributionRanges.Select(item => new MapLocationForProudect()
                    {
                        GovernorateNameInEnglish = item.Governorate.NameInEnglish??"",
                        GovernorateNameInArabic=item.Governorate.NameInArabic??"",
                        City = item.City,
                        station = item.station

                    }).ToList(),
                    InternationalBarcode = Proudect.InternationalBarcode,
                    PharmaceuticalFormId = Proudect.PharmaceuticalForm.Id,
                    PharmaceuticalFormName = Proudect.PharmaceuticalForm.Name,
                    pharmacology = Proudect.pharmacology,
                    Price = Proudect.Price,
                    ProudectImage = ImagesUtilities.GetImage(Proudect.Images.FirstOrDefault(img => img.Type == (int)ImageTypes.Proudect).Path),
                    ProudectLicence = ImagesUtilities.GetImage(Proudect.Images.FirstOrDefault(img => img.Type == (int)ImageTypes.ProudectLicence).Path),
                    TaxRegistrationNumber = Proudect.TaxRegistrationNumber,
                    TaxRegistrationYear = Proudect.TaxRegistrationYear,
                },
                    Status = 200,
                    isSuccess = true

                };




            }

            catch ( Exception ex)
            {

                return new ApiResponse<ProudectResponse>()
                {
                    Message = " this Proudect Not Updated",
                    Data = null,
                    Status = 200,
                    isSuccess = false

                };
            }
            throw new NotImplementedException();
        }
        public async Task<ApiResponse<List<AllProudectsResponse>>> GetProudectsByActiveSubstances(string ActiveSubstance)
        {
            var Proudects = await _Context.Proudects
 .Include(pr => pr.AppUser)

 .Include(pr => pr.Images)

 .Where(pr => pr.ActiveProudect == true && pr.ActiveSubstances.Contains(ActiveSubstance))
 .OrderByDescending(pr => pr.Priority)
 .ToListAsync();

            if (Proudects.Any())
            {

                List<AllProudectsResponse> ProudectsRes = new List<AllProudectsResponse>();
                foreach (var Proudect in Proudects)
                {
                    ProudectsRes.Add(new AllProudectsResponse()
                    {
                        Id = Proudect.Id,
                        NameInArabic = Proudect.NameInArabic,
                        NameInEnglish = Proudect.NameInEnglish,
                        ActiveSubstances = Proudect.ActiveSubstances,
                        AppUser = Proudect.AppUser,
                        CompanyNameInEnglish = Proudect.CompanyNameInEnglish,
                        Discount = Proudect.Discount,
                        Discription = Proudect.Discription,
                        FactoryNameInEnglish = Proudect.FactoryNameInEnglish,
                        Price = Proudect.Price,
                        AgentRequest = Proudect.AgentRequest,
                        ProudectImage = ImagesUtilities.GetImage(Proudect.Images.FirstOrDefault(img => img.Type == (int)ImageTypes.Proudect).Path),

                    });
                }




                return new ApiResponse<List<AllProudectsResponse>>()
                {
                    Message = "There are our Proudects",
                    Data = ProudectsRes,
                    Status = 200,
                    isSuccess = true

                };
            }
            return new ApiResponse<List<AllProudectsResponse>>()
            {
                Message = "We don't have any Proudects",
                Data = null,
                Status = 200,
                isSuccess = false

            };


        }

        private void AddGeographicalDistributionRang(List<GeographicalDistributionRangRej> list, Guid ProudectId)
        {
            foreach (var item in list)
            {
                _Context.GeographicalDistributionRanges.Add(new GeographicalDistributionRange()
                {

                    Id = Guid.NewGuid(),
                   ProudectId=ProudectId,

                    City = item.City,
                    station = item.station,
                    GovernorateId = item.GovernorateId

                });
            }

            _Context.SaveChanges();
        }
    }
}