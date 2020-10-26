

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Repositories;
using Core.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        //ILogger<HomeController> logger

        private readonly IMusicRepository _musicRepository;
        private readonly IDetailRepository _detailRepository;
        private readonly ICommentRepository _commentRepository;
        private readonly ViewModel _viewModel;
        public HomeController(IMusicRepository musicRepository, ViewModel viewModel,IDetailRepository detailRepository,ICommentRepository commentRepository)
        {
            _musicRepository = musicRepository;
            _viewModel = viewModel;
            _detailRepository = detailRepository;
            _commentRepository = commentRepository;
        }

        public async Task<IActionResult> Index()
        {
            var getPopularMusics = await _musicRepository.GetPopularMusics();
            var getLast5Music = await _musicRepository.GetLast5();
            var getTopUsers = await _detailRepository.GetTopUsers();
            var getLastComments = await _commentRepository.GetLast5Comments();

            _viewModel.PopularMusics = getPopularMusics;
            _viewModel.Comments = getLastComments;
            _viewModel.UserDetails = getTopUsers;
            _viewModel.LastMusics = getLast5Music;
            return View(_viewModel);
        }

        public IActionResult Privacy()
        {

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
