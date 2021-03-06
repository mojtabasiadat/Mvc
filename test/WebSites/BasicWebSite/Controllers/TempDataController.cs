// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace BasicWebSite.Controllers
{
    public class TempDataController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DisplayTempData(string value)
        {
            TempData["key"] = value;
            return View();
        }

        public IActionResult SetTempData(string value)
        {
            TempData["key"] = value;
            return Content(value);
        }

        public IActionResult GetTempDataAndRedirect()
        {
            var value = TempData["key"];
            return RedirectToAction("GetTempData");
        }

        public string GetTempData()
        {
            var value = TempData["key"];
            return value?.ToString();
        }

        public IActionResult PeekTempData()
        {
            var peekValue = TempData.Peek("key");
            return Content(peekValue.ToString());
        }

        public IActionResult SetTempDataMultiple(
            string value,
            int intValue,
            IList<string> listValues,
            DateTime datetimeValue,
            Guid guidValue)
        {
            TempData["key1"] = value;
            TempData["key2"] = intValue;
            TempData["key3"] = listValues;
            TempData["key4"] = datetimeValue;
            TempData["key5"] = guidValue;
            return RedirectToAction("GetTempDataMultiple");
        }

        public string GetTempDataMultiple()
        {
            var value1 = TempData["key1"].ToString();
            var value2 = Convert.ToInt32(TempData["key2"]);
            var value3 = (IList<string>)TempData["key3"];
            var value4 = (DateTime)TempData["key4"];
            var value5 = (Guid)TempData["key5"];
            return $"{value1} {value2.ToString()} {value3.Count.ToString()} {value4.ToString()} {value5.ToString()}";
        }

        [HttpGet]
        public IActionResult SetTempDataInActionResult()
        {
            return new StoreIntoTempDataActionResult();
        }

        [HttpGet]
        public string GetTempDataSetInActionResult()
        {
            return TempData["Name"]?.ToString();
        }

        [HttpGet]
        public IActionResult SetLargeValueInTempData(int size, char character)
        {
            TempData["LargeValue"] = new string(character, size);
            return Ok();
        }

        [HttpGet]
        public string GetLargeValueFromTempData()
        {
            return TempData["LargeValue"]?.ToString();
        }
    }
}
