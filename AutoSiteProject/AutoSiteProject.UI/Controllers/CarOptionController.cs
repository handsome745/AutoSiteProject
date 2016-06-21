using AutoMapper;
using AutoSiteProject.Models.Bl.Interfaces;
using AutoSiteProject.Models.DB;
using AutoSiteProject.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoSiteProject.UI.Controllers
{
    public class CarOptionController : Controller
    {
        private ICarOptionManager _carOptionManager;
        public CarOptionController(ICarOptionManager carOptionManager)
        {
            _carOptionManager = carOptionManager;
        }

        // GET
        public ActionResult List()
        {
            return View(Mapper.Map<CarOptionViewModel>(_carOptionManager.GetAll().ToList()));
        }


        //GET 
        public ActionResult Create()
        {
            return View();
        }
        //Post
        [HttpPost]
        public ActionResult Create(CarOptionViewModel entity)
        {
            if (ModelState.IsValid)
            {
                _carOptionManager.Add(Mapper.Map<CarOption>(entity));
                return RedirectToAction("List");
            }
            return View(entity);
        }

        //GET 
        public ActionResult Edit(int id)
        {
            return View(Mapper.Map<CarOptionViewModel>(_carOptionManager.GetById(id)));
        }
        //Post
        [HttpPost]
        public ActionResult Edit(CarOptionViewModel entity)
        {
            if (ModelState.IsValid)
            {
                _carOptionManager.Edit(Mapper.Map<CarOption>(entity));
                return RedirectToAction("List");
            }
            return View(entity);
        }

        //GET 
        public ActionResult Delete(int id)
        {
            _carOptionManager.Delete(id);
            return RedirectToAction("List");
        }
    }
}