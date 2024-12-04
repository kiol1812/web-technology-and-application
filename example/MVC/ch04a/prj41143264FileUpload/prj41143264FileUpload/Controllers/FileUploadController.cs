﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace prj41143264FileUpload.Controllers
{
    public class FileUploadController : Controller
    {
        // GET: FileUpload
        public ActionResult Index()
        {
            return View();
        }

        // GET: Home
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(HttpPostedFileBase photo)
        {
            //上傳圖檔名稱
            string fileName = "";
            //檔案上傳
            if (photo != null)
            {
                if (photo.ContentLength > 0)
                {
                    //取得圖檔名稱
                    fileName = Path.GetFileName(photo.FileName);
                    var path = Path.Combine
                      (Server.MapPath("~/Photos"), fileName);
                    photo.SaveAs(path);
                }
            }
            return RedirectToAction("ShowPhotos");
        }

        // ShowPhotos方法使用ContentResult傳回HTML
        // 可顯示Photos資料夾下所有圖檔
        public ContentResult ShowPhotos()
        {
            string strHtml = "";
            // 建立可操作Photos資料夾的dir物件
            DirectoryInfo dir =
                new DirectoryInfo(Server.MapPath("~/Photos"));
            //取得dir物件下的所有檔案(即photos資料夾下)並放入finfo檔案資訊陣列
            FileInfo[] fInfo = dir.GetFiles();
            // 逐一將finfo檔案資訊陣列內的所有圖檔指定給strHtml變數
            foreach (FileInfo result in fInfo)
            {
                // 將顯示圖的HTML字串指定給strHtml
                strHtml += $"<a href='../Photos/{result.Name}' target='_blank'>" +
                    $"<img src='../Photos/{result.Name}' width='150' height='120' border='0'>" +
                    $"</a>　";
            }
            // strHtml變數再加上 '返回' Create動作方法的連結
            strHtml += "<p><a href='Create'>返回</a></p>";
            return Content(strHtml, "text/html", System.Text.Encoding.UTF8);
        }
    }
}