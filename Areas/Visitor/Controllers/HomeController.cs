using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewsSite.Data;
using NewsSite.Models;
using NewsSite.Models.ViewModels;
using NewsSite.Repository.IRepostiory;
using NewsSite.Utility;

namespace NewsSite.Controllers
{

    [Area("Visitor")]
    public class HomeController : Controller
    {



        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<IActionResult> Index()
        {
            IndexViewModel IndexVM = new IndexViewModel()
            {
                News = await _unitOfWork.News.GetAllAsync(includeProperties: "Category"), 
                Category = await _unitOfWork.Categories.GetAllAsync(),
            };
            return View(IndexVM);
        }

        [Authorize]
        public async Task<IActionResult> Details(int id)
        {
            var NewsFromDb = await _unitOfWork.News.GetAsync(m => m.Id == id, includeProperties: "Category");
            return View(NewsFromDb);
        }
    }
}
