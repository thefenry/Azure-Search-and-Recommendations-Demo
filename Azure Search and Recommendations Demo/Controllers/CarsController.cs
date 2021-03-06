﻿using Azure_Search_and_Recommendations_Demo.AzureSearchModels;
using Azure_Search_and_Recommendations_Demo.DAL;
using Azure_Search_and_Recommendations_Demo.Interfaces;
using Azure_Search_and_Recommendations_Demo.Models;
using Azure_Search_and_Recommendations_Demo.Services;
using AzureSearchService;
using RecommendationsServiceLibrary;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web.Http.Cors;
using System.Web.Mvc;

namespace Azure_Search_and_Recommendations_Demo.Controllers
{
    public class CarsController : Controller
    {
        private SearchContext db = new SearchContext();
        private AzureSearchManager azureSearchManager = new AzureSearchManager();

        // GET: Cars
        public ActionResult Index()
        {
            return View(db.Cars.ToList());
        }

        // GET: Cars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // GET: Cars/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Make,Model,Year,Rating")] Car car)
        {
            if (ModelState.IsValid)
            {
                db.Cars.Add(car);
                db.SaveChanges();

                List<CarSearchModel> carDocument = new List<CarSearchModel>()
                {
                    new CarSearchModel
                    {
                        Id = car.Id.ToString(),
                       Make = car.Make,
                       Model = car.Model,
                       Year = car.Year,
                       Rating = car.Rating
                    }
                };
                azureSearchManager.AddOrUpdateDocumentToIndex(carDocument, "cars");

                return RedirectToAction("Index");
            }

            return View(car);
        }

        // GET: Cars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Make,Model,Year,Rating")] Car car)
        {
            if (ModelState.IsValid)
            {
                db.Entry(car).State = EntityState.Modified;
                db.SaveChanges();

                List<CarSearchModel> carDocument = new List<CarSearchModel>()
                {
                    new CarSearchModel
                    {
                        Id = car.Id.ToString(),
                       Make = car.Make,
                       Model = car.Model,
                       Year = car.Year,
                       Rating = car.Rating
                    }
                };

                azureSearchManager.AddOrUpdateDocumentToIndex(carDocument, "cars");

                return RedirectToAction("Index");
            }
            return View(car);
        }

        // GET: Cars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Car car = db.Cars.Find(id);
            db.Cars.Remove(car);
            db.SaveChanges();

            List<CarSearchModel> carDocument = new List<CarSearchModel>()
                {
                    new CarSearchModel
                    {
                        Id = car.Id.ToString(),
                       Make = car.Make,
                       Model = car.Model,
                       Year = car.Year,
                       Rating = car.Rating
                    }
                };

            azureSearchManager.DeleteDocumentInIndex(carDocument, "cars");

            return RedirectToAction("Index");
        }

        public ActionResult CreateIndex()
        {
            return View();
        }

        [HttpPost, ActionName("CreateIndex")]
        [ValidateAntiForgeryToken]
        public ActionResult CreateIndexPost()
        {
            azureSearchManager.CreateIndex<Car>("cars");

            return RedirectToAction("Index");
        }

        [HttpPost]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public ActionResult CreateCars(List<Car> cars)
        {
            azureSearchManager.CreateIndex<Car>("cars");

            return RedirectToAction("Index");
        }

        public ActionResult CreateRecommendationsModel()
        {
            string modelName = "CarsRecommendationModel";
            string description = "TestingDesc";
            string baseUri = "https://westus.api.cognitive.microsoft.com/recommendations/v4.0";

            RecommendationsLibrary recommendationsLibrary = new RecommendationsLibrary("270d8ea401774398a4ef01286d5d952e", baseUri);
            var test = recommendationsLibrary.CreateModel(modelName, description);
            return View();
        }

        public ActionResult UploadCatalog()
        {
            ICsvFileConverter csvFileConverter = new CsvFileConverter();
            FileInfo fileInfo = csvFileConverter.ConvertModelToCsv(db.Cars.ToList());
            string baseUri = "https://westus.api.cognitive.microsoft.com/recommendations/v4.0";
            RecommendationsLibrary recommendationsLibrary = new RecommendationsLibrary("270d8ea401774398a4ef01286d5d952e", baseUri);
            var test = recommendationsLibrary.UploadModel("7c4fd779-2363-49ac-8525-f904139cab2c", fileInfo.Name, fileInfo.FullName);

            //"579cd5a2-150b-402b-868a-e6d3fdc7867f"
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
