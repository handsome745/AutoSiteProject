using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoSiteProject.Models.Bl.Interfaces;
using AutoSiteProject.Models.ViewModels;
using AutoMapper;
using AutoSiteProject.Models.DB;

namespace AutoSiteProject.UI.Controllers
{
    public class CarBodyTypeController : Controller
    {
        private ICarBodyTypeManager _carBodyTypeManager;

        public CarBodyTypeController(ICarBodyTypeManager carBodyTypeManager)
        {
            _carBodyTypeManager = carBodyTypeManager;
        }


        // GET: CarModel
        public ActionResult List()
        {
            return View(Mapper.Map<List<CarBodyTypeViewModel>>(_carBodyTypeManager.GetAll()));
        }


        //GET 
        public ActionResult Create()
        {
            return View();
        }
        //Post
        [HttpPost]
        public ActionResult Create(CarBodyTypeViewModel entity)
        {
            if (ModelState.IsValid)
            {
                _carBodyTypeManager.Add(Mapper.Map<CarBodyType>(entity));
                return RedirectToAction("List");
            }
            return View(entity);
        }

        //GET 
        public ActionResult Edit(int id)
        {
            return View(Mapper.Map<CarBodyTypeViewModel>(_carBodyTypeManager.GetById(id)));
        }
        //Post
        [HttpPost]
        public ActionResult Edit(CarBodyTypeViewModel entity)
        {
            if (ModelState.IsValid)
            {
                _carBodyTypeManager.Edit(Mapper.Map<CarBodyType>(entity));
                return RedirectToAction("List");
            }
            return View(entity);
        }

        //GET 
        public ActionResult Delete(int id)
        {
            _carBodyTypeManager.Delete(id);
            return RedirectToAction("List");
        }
    }
}