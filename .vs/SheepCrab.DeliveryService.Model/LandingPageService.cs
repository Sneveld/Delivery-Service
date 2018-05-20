using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using DataContext;
using SheepCrab.DeliveryService.DataAccess.Interfaces;
using SheepCrab.DeliveryService.Dto.ViewModels;
using SheepCrab.DeliveryService.Model.Interfaces;

namespace SheepCrab.DeliveryService.Model
{
    public class LandingPageService : ILandingPageService
    {
        private readonly ILandingPageImagesRepository _landingPageImagesRepository;
        private readonly IMapper _mapper;

        public LandingPageService(
            ILandingPageImagesRepository landingPageImagesRepository,
            IMapper mapper
            )
        {
            _landingPageImagesRepository = landingPageImagesRepository;
            _mapper = mapper;
        }

        public IEnumerable<LandingPageImageViewModel> GetAllLandingPageImages()
        {
            return _mapper.Map<List<LandingPageImageViewModel>>(_landingPageImagesRepository.GetAll());
        }
    }
}