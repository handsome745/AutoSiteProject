﻿using AutoMapper;
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
    public class CountryController : Controller
    {
        private ICountryManager _countryManager;

        public CountryController(ICountryManager countryManager)
        {
            _countryManager = countryManager;
        }

        // GET: Country
        public ActionResult List()
        {
            return View(Mapper.Map<CountryViewModel>(_countryManager.GetAll()));
        }

        //GET 
        public ActionResult Create()
        {
            return View();
        }
        //Post
        [HttpPost]
        public ActionResult Create(CountryViewModel entity)
        {
            if (ModelState.IsValid)
            {
                _countryManager.Add(Mapper.Map < Country>(entity));
                return RedirectToAction("List");
            }
            return View(entity);
        }

        //GET 
        public ActionResult Edit(int id)
        {
            return View(Mapper.Map<Country>(_countryManager.GetById(id)));
        }
        //Post
        [HttpPost]
        public ActionResult Edit(CountryViewModel entity)
        {
            if (ModelState.IsValid)
            {
                _countryManager.Edit(Mapper.Map<Country>(entity));
                return RedirectToAction("List");
            }
            return View(entity);
        }

        //GET 
        public ActionResult Delete(int id)
        {
            _countryManager.Delete(id);
            return RedirectToAction("List");
        }

    }
}