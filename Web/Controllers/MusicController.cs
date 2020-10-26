using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Models;
using Core.Repositories;
using Core.Service;
using Core.ViewModels;
using Data;
using Data.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Web.Controllers
{
    public class MusicController : Controller
    {
        private readonly ViewModel _viewModel;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMusicRepository _musicDetailRepository;
        private readonly IRepository<Music> _musicRepository;
        private readonly ILikeRepository _likeRepository;
        private readonly IDetailRepository _detailRepository;
        private readonly ICommentRepository _commentRepository;
        private readonly zumuziDbContext _context;

        public MusicController(ICategoryRepository categoryRepository, IMusicRepository musicRepository,
            ICommentRepository commentRepository, ViewModel viewModel, zumuziDbContext context, IDetailRepository detailRepository, ILikeRepository likeRepository)
        {
            _viewModel = viewModel;
            _categoryRepository = categoryRepository;
            _musicRepository = musicRepository;
            _musicDetailRepository = musicRepository;
            _commentRepository = commentRepository;
            _detailRepository = detailRepository;
            _likeRepository = likeRepository;
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var musics = await _musicRepository.GetAllAsync();
            _viewModel.LastMusics = musics;
            return View(_viewModel);
        }

        public async Task<IActionResult> AddMusic()
        {
            ViewBag.Category = new SelectList(await _categoryRepository.GetCategories(), "CategoryId", "CategoryName");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddMusic(Music music, int userId)
        {
            music.UserDetailId = userId;
            var user = await _detailRepository.GetByIdAsync(userId);
            user.TotalScore += _detailRepository.GiveRandomScore(1);
            await _musicRepository.AddAsync(music);
            return RedirectToAction("Index", "Music");
        }
        [Authorize]
        public async Task<IActionResult> Detail(int id)
        {
            var detail = await _musicDetailRepository.GetDetailsById(id);
            var musicComment = await _commentRepository.GetCommentsByMusicId(id);
            _viewModel.Comments = musicComment;
            _viewModel.Music = detail;
            return View(_viewModel);
        }


        [HttpPost]
        public async Task<IActionResult> AddComment(Comment comment, int id, int userId)
        {
            comment.MusicId = id;
            comment.UserDetailId = userId;
            var user = await _detailRepository.GetByIdAsync(userId);
            var music = await _musicRepository.GetByIdAsync(id);
            user.TotalComments++;
            user.TotalScore += _detailRepository.GiveRandomScore();
            music.TotalComments++;
            await _commentRepository.AddAsync(comment);
            return RedirectToAction("Index", "Music");
        }

        [HttpGet]
        public async Task<bool> Like(int musicId, int userId)
        {
            var control = await _likeRepository.LikeControl(userId, musicId);
            if (control)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        [HttpPost]
        public async Task<bool> Like(int musicId, int userId, Like like)
        {
            var music = await _musicRepository.GetByIdAsync(musicId);
            var user = await _detailRepository.GetByIdAsync(userId);

            var control = await _likeRepository.LikeControl(userId, musicId);
            if (control)//true
            {
                var deleteLike = _context.Likes.FirstOrDefaultAsync(x => x.UserId == userId && x.MusicId == musicId).Result;
                _likeRepository.Remove(deleteLike);
                music.TotalLikes--;
                user.TotalLikes--;
                user.TotalScore += _detailRepository.GiveRandomScore(2);
                await _context.SaveChangesAsync();
                return true;
            }
            else//false
            {
                await _likeRepository.AddAsync(like);
                music.TotalLikes++;
                user.TotalLikes++;
                user.TotalScore += _detailRepository.GiveRandomScore();
                await _context.SaveChangesAsync();
                return false;
            }
        }
    }
}
