using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Xml;

namespace prj41143264XMLDOM.Controllers
{
    public class XMLDOMController : Controller
    {
        // GET: XMLDOM
        public ActionResult Index()
        {
            return View();
        }
        public string Example1()
        {
            string show = "";
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("http://140.130.34.14/dom/javascript/book1.xml");
            //xmlDoc.Load("book1.xml");
            //book1.xml 需存放在C:\Program Files (x86)\IIS Express 目錄下

            show += "<hr /><h2>資料顯示</h2><hr />";
            show += xmlDoc.GetElementsByTagName("title")[0].InnerText + "<br />";
            show += xmlDoc.GetElementsByTagName("author")[0].InnerText + "<br />";
            show += xmlDoc.GetElementsByTagName("year")[0].InnerText + "<br />";
            show += "<hr /> 課程:Web技術與應用";
            return show;
        }
        public string Example2()
        {
            string show = "";
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("http://140.130.34.14/dom/javascript/book2.xml");
            show += "<hr /><h2>資料顯示</h2><hr />";
            XmlNodeList titleNodeList = xmlDoc.GetElementsByTagName("title");
            for (int i = 0; i < titleNodeList.Count; i++)
                show += titleNodeList[i].InnerText + "<br />";
            show += "<hr /> 課程:Web技術與應用";
            return show;
        }
        public string Example3()
        {
            string show = "";
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("http://140.130.34.14/dom/javascript/book3.xml");
            show += "<hr /><h2>資料顯示</h2><hr />";
            show += xmlDoc.GetElementsByTagName("title")[0].InnerText + "<br />";
            show += xmlDoc.GetElementsByTagName("author")[0].InnerText + "<br />";
            show += xmlDoc.GetElementsByTagName("year")[0].InnerText + "<br />";
            show += "<hr /> 課程:Web技術與應用";
            return show;
        }
        public string Example4()
        {
            string show = "";
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("http://140.130.34.14/dom/javascript/book2.xml");
            XmlNodeList fnodeList = xmlDoc.DocumentElement.ChildNodes;
            //取出根標籤(Documentlement)(bookstore)下的第一層子標籤(book)
            show += "<hr /><h2>資料顯示</h2><hr />";
            for (int i = 0; i < fnodeList.Count; i++)
            {
                if (fnodeList[i].NodeType.ToString() == "Element")  //Process only element nodes (type 1 是Element)         
                    show += fnodeList[i].Name + "<br />";
            }
            show += "<hr /> 課程:Web技術與應用";
            return show;
        }
        public string DOMHW1()
        {
            string show = "";
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("http://140.130.34.14/dom/javascript/book2.xml");
            XmlNodeList fnodeList = xmlDoc.DocumentElement.ChildNodes;
            //取出根標籤(Documentlement)(bookstore)下的第一層子標籤(book)
            show += "<hr /><h2>資料顯示</h2><hr />";
            for (int i = 0; i < fnodeList.Count; i++)
            {
                if (fnodeList[i].NodeType.ToString() == "Element") {  //Process only element nodes (type 1 是Element)         
                    show += fnodeList[i].Name + "<br />";
                    // show += fnodeList[i]+ "<br />";
                    XmlNodeList book = fnodeList[i].ChildNodes;
                    for (int j = 0; j < book.Count; ++j)
                        if (book[j].NodeType.ToString() == "Element") show += book[j].Name+" "+ book[j].InnerText + "<br />";
                }
            }
            show += "<hr /> 課程:Web技術與應用";
            return show;
        }
        public string Example5()
        {
            string show = "";
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("http://140.130.34.14/dom/javascript/book3.xml");
            XmlNodeList xnodeList = xmlDoc.GetElementsByTagName("book")[0].ChildNodes;
            //取出第一個book標籤內下的所有子標籤
            XmlNode currentNode = xmlDoc.GetElementsByTagName("book")[0].FirstChild;
            //取出第一個book標籤內下的第一個子標籤(title)
            show += "<h2>資料顯示</h2><hr />";
            for (int i = 0; i < xnodeList.Count; i++)
            {
                if (currentNode.NodeType.ToString() == "Element")
                {
                    show += currentNode.Name + " : ";
                    show += currentNode.InnerText + "<br />";
                    currentNode = currentNode.NextSibling;
                }
            }
            show += "<hr /> 課程:Web技術與應用";
            return show;
        }
        public string Example6()
        {
            string show = "";
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("http://140.130.34.14/dom/javascript/book1.xml");
            show += xmlDoc.GetElementsByTagName("title")[0].InnerText + " <br/>";
            show += xmlDoc.GetElementsByTagName("title")[0].Attributes["lang"].Value;
            show += "<hr /> 課程:Web技術與應用";
            return show;
        }
        public string Example7()
        {
            string show = "";
            string text = "";
            XmlDocument xmlDoc = new XmlDocument();
            text = "<bookstore><book>";
            text = text + "<title>Everyday Italian</title>";
            text = text + "<author>Giada De Laurentiis</author>";
            text = text + "<year>2005</year>";
            text = text + "</book></bookstore>";
            xmlDoc.LoadXml(text);
            show += "<h2>資料顯示</h2><hr />";
            show += xmlDoc.GetElementsByTagName("title")[0].InnerText + " <br/>";
            show += xmlDoc.GetElementsByTagName("author")[0].InnerText + " <br/>";
            show += xmlDoc.GetElementsByTagName("year")[0].InnerText + " <br/>";
            show += "<hr /> 課程:Web技術與應用";
            return show;
        }
        public string Example8()
        {
            string show = "";
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("http://140.130.34.14/dom/javascript/book3.xml");
            XmlNodeList nodeList = xmlDoc.GetElementsByTagName("book")[0].ChildNodes;
            //取出第一個book標籤內下的所有子標籤
            show += "<h2>資料顯示</h2><hr />";
            show += "<table border='1'><tr><td>節點</td><td>內容</td></tr>";
            for (int i = 0; i < nodeList.Count; i++)
            {
                show += "<tr><td>" + nodeList[i].Name + "</td>";
                show += "<td>" + nodeList[i].InnerText + "</td></tr>";
            }
            show += "</table>";
            show += xmlDoc.GetElementsByTagName("title")[0].InnerText + " <br/>";
            show += xmlDoc.GetElementsByTagName("title")[0].Attributes["lang"].Value;
            show += "<hr /> 課程:Web技術與應用";
            return show;
        }
        public string Example9()
        {
            string show = "";
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("http://140.130.34.14/dom/javascript/book4.xml");
            show += "<h2>顯示XML文件的節點元素和屬性</h2><hr />";
            show += xmlDoc.DocumentElement.Name + " (" + xmlDoc.DocumentElement.InnerText + ")<br />";
            //顯示根元素名稱(booklist)
            XmlNodeList fnodeList = xmlDoc.DocumentElement.ChildNodes;
            //取出根標籤(Documentlement)(booklist)下的第一層子標籤(book)
            for (int i = 0; i < fnodeList.Count; i++)
            {
                show += "&nbsp;&nbsp;+-- " + i + ":" + fnodeList[i].Name;
                show += "(" + fnodeList[i].InnerText + ") <br />";
                if (fnodeList[i].HasChildNodes)
                {
                    XmlNodeList snodeList = fnodeList[i].ChildNodes;
                    //取出第一層子標籤下的子標籤(相對根表籤是第二層)(code, title, authorlist, price)
                    for (int j = 0; j < snodeList.Count; j++)
                    {
                        show += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;+-- " + snodeList[j].Name;
                        show += "(" + snodeList[j].InnerText + ")<br />";
                    }
                }
            }
            show += "<hr />";
            XmlNodeList books = xmlDoc.GetElementsByTagName("book");
            for (int i = 0; i < books.Count; i++)
            {
                show += books[i].Name + "(" + i + "):";
                show += books[i].Attributes["sales"].Value + "&nbsp;&nbsp;";
            }
            show += "<hr /> 課程:Web技術與應用";
            return show;
        }

        public string DOMHW2_1()
        {
            string show = "";
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("http://140.130.34.14/dom/javascript/book4.xml");
            XmlNodeList nodeList = xmlDoc.GetElementsByTagName("book")[0].ChildNodes;
            //取出第一個book標籤內下的所有子標籤
            show += "<h2>書名表格顯示</h2><hr />";
            show += "<table border='1'><tr><td>書號</td><td>書名</td><td>作者</td><td>價錢</td></tr>";
            for (int j=0; j< xmlDoc.GetElementsByTagName("book").Count; ++j)
            {
                nodeList = xmlDoc.GetElementsByTagName("book")[j].ChildNodes;
                show += "<tr>";
                for (int i = 0; i < nodeList.Count; i++)
                {
                    // show += "<td>" + nodeList[i].Name + "</td>";
                    show += "<td>" + nodeList[i].InnerText + "</td>";
                }
                show += "</tr>";
            }
            show += "</table>";
            // show += xmlDoc.GetElementsByTagName("title")[0].InnerText + " <br/>";
            // show += xmlDoc.GetElementsByTagName("title")[0].Attributes["lang"].Value;
            show += "<hr /> 課程:Web技術與應用";
            return show;
        }
        public string DOMHW2_2()
        {
            string show = "";
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("http://140.130.34.14/dom/javascript/book5.xml");
            XmlNodeList nodeList = xmlDoc.GetElementsByTagName("book")[0].ChildNodes;
            //取出第一個book標籤內下的所有子標籤
            show += "<h2>書名表格顯示</h2><hr />";
            show += "<table border='1'><tr><td>書號</td><td>書名</td><td>作者</td><td>價錢</td></tr>";
            for (int j = 0; j < xmlDoc.GetElementsByTagName("book").Count; ++j)
            {
                nodeList = xmlDoc.GetElementsByTagName("book")[j].ChildNodes;
                show += "<tr>";
                for (int i = 0; i < nodeList.Count; i++)
                {
                    // show += "<td>" + nodeList[i].Name + "</td>";
                    show += "<td>" + nodeList[i].InnerText + "</td>";
                }
                show += "</tr>";
            }
            show += "</table>";
            // show += xmlDoc.GetElementsByTagName("title")[0].InnerText + " <br/>";
            // show += xmlDoc.GetElementsByTagName("title")[0].Attributes["lang"].Value;
            show += "<hr /> 課程:Web技術與應用";
            return show;
        }

        public string DOMHW3()
        {
            string show = "";
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("http://140.130.34.14/dom/javascript/book5.xml");
            XmlNodeList nodeList = xmlDoc.GetElementsByTagName("book")[0].ChildNodes;
            //取出第一個book標籤內下的所有子標籤
            show += "<h2>書名表格顯示</h2><hr />";
            show += "<table border='1'><tr><td>書號</td><td>書名</td><td>作者</td><td>價錢</td><td>是否有存貨</td></tr>";
            for (int j = 0; j < xmlDoc.GetElementsByTagName("book").Count; ++j)
            {
                nodeList = xmlDoc.GetElementsByTagName("book")[j].ChildNodes;
                show += "<tr>";
                for (int i = 0; i < nodeList.Count; i++)
                {
                    // show += "<td>" + nodeList[i].Name + "</td>";
                    show += "<td>" + nodeList[i].InnerText + "</td>";
                }
                show += "<td>" + xmlDoc.GetElementsByTagName("book")[j].Attributes["sales"].Value + "</td>";
                show += "</tr>";
            }
            show += "</table>";
            // show += xmlDoc.GetElementsByTagName("title")[0].InnerText + " <br/>";
            // show += xmlDoc.GetElementsByTagName("title")[0].Attributes["lang"].Value;
            show += "<hr /> 課程:Web技術與應用";
            return show;
        }
        public string DOMHW4()
        {
            string show = "";
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("http://140.130.34.14/dom/javascript/book5.xml");
            XmlNodeList nodeList = xmlDoc.GetElementsByTagName("book")[0].ChildNodes;
            //取出第一個book標籤內下的所有子標籤
            show += "<h2>書名表格顯示</h2><hr />";
            show += "<table border='1'><tr><td>書號</td><td>書名</td><td>作者</td><td>價錢</td><td>是否有存貨</td></tr>";
            for (int j = 0; j < xmlDoc.GetElementsByTagName("book").Count; ++j)
            {
                nodeList = xmlDoc.GetElementsByTagName("book")[j].ChildNodes;
                show += "<tr>";
                for (int i = 0; i < nodeList.Count; i++)
                {
                    // show += "<td>" + nodeList[i].Name + "</td>";
                    if (nodeList[i].Name == "authorlist") { 
                        show += "<td>";
                        for (int k=0; k<nodeList[i].ChildNodes.Count; ++k) show += nodeList[i].ChildNodes[k].InnerText + "<br/>";
                        show += "</td>";
                    }else
                        show += "<td>" + nodeList[i].InnerText + "</td>";
                }
                show += "<td>" + xmlDoc.GetElementsByTagName("book")[j].Attributes["sales"].Value + "</td>";
                show += "</tr>";
            }
            show += "</table>";
            // show += xmlDoc.GetElementsByTagName("title")[0].InnerText + " <br/>";
            // show += xmlDoc.GetElementsByTagName("title")[0].Attributes["lang"].Value;
            show += "<hr /> 課程:Web技術與應用";
            return show;
        }
        public string DOMHW5()
        {
            string show = "";
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("http://140.130.34.14/dom/javascript/book5.xml");
            show += "<h2>顯示XML文件的節點元素和屬性</h2><hr />";
            show += xmlDoc.DocumentElement.Name + " (" + xmlDoc.DocumentElement.InnerText + ")<br />";
            //顯示根元素名稱(booklist)
            XmlNodeList fnodeList = xmlDoc.DocumentElement.ChildNodes;
            //取出根標籤(Documentlement)(booklist)下的第一層子標籤(book)
            for (int i = 0; i < fnodeList.Count; i++)
            {
                show += "&nbsp;&nbsp;+-- " + i + ":" + fnodeList[i].Name;
                show += "(" + fnodeList[i].InnerText + ") <br />";
                if (fnodeList[i].HasChildNodes)
                {
                    XmlNodeList snodeList = fnodeList[i].ChildNodes;
                    //取出第一層子標籤下的子標籤(相對根表籤是第二層)(code, title, authorlist, price)
                    for (int j = 0; j < snodeList.Count; j++)
                    {
                        show += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;+-- " + snodeList[j].Name;
                        show += "(" + snodeList[j].InnerText + ")<br />";
                        XmlNodeList tnodelist = snodeList[j].ChildNodes;
                        if (snodeList[j].HasChildNodes)
                        {
                            for (int k = 0; k < tnodelist.Count; k++)
                            {
                                show += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;+-- " + tnodelist[k].Name;
                                show += "(" + tnodelist[k].InnerText + ")<br />";
                            }
                        }

                    }
                }
            }

            show += "<hr />";
            XmlNodeList books = xmlDoc.GetElementsByTagName("book");
            for (int i = 0; i < books.Count; i++)
            {
                show += books[i].Name + "(" + i + "):";
                show += books[i].Attributes["sales"].Value + "&nbsp;&nbsp;";
            }
            show += "<hr /> 課程:Web技術與應用";
            return show;
        }

        public string DOMHW6()
        {
            string show = "";
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("https://data.moenv.gov.tw/api/v2/aqx_p_432?api_key=e8dd42e6-9b8b-43f8-991e-b3dee723a52d&limit=1000&sort=ImportDate%20desc&format=XML");
            show += "<h2>台灣各區域PM2.5值</h2><hr />";
            // show += xmlDoc.DocumentElement.Name + " (" + xmlDoc.DocumentElement.InnerText + ")<br />";
            show += "<table border='1'><tr><td>測站名稱</td><td>縣市名稱</td><td>空氣品質</td><td>資料建構日期</td><td>PM2.5</td></tr>";
            XmlNodeList fnodeList = xmlDoc.DocumentElement.ChildNodes;
            for (int i = 0; i < fnodeList.Count; i++)
            {
                if (fnodeList[i].HasChildNodes)
                {
                    show += "<tr>";
                    XmlNodeList snodeList = fnodeList[i].ChildNodes;
                    //取出第一層子標籤下的子標籤(相對根表籤是第二層)(code, title, authorlist, price)
                    for (int j = 0; j < snodeList.Count; j++)
                    {
                        // show += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;+-- " + snodeList[j].Name;
                        if(snodeList[j].Name=="sitename"|| snodeList[j].Name == "county" || snodeList[j].Name == "status" || snodeList[j].Name == "publishtime") show += "<td>" + snodeList[j].InnerText + "</td>";
                    }
                    for (int j = 0; j < snodeList.Count; j++) if (snodeList[j].Name == "pm2.5") show += "<td>" + snodeList[j].InnerText + "</td>";
                    show += "</tr>";
                }
            }
            show += "</table><hr />";
            show += "<hr />";
            return show;
        }

        public string DOMHW7()
        {
            string show = "";
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("https://data.moenv.gov.tw/api/v2/aqx_p_432?api_key=e8dd42e6-9b8b-43f8-991e-b3dee723a52d&limit=1000&sort=ImportDate%20desc&format=XML");
            show += "<h2>台灣各區域PM2.5值</h2><hr />";
            // show += xmlDoc.DocumentElement.Name + " (" + xmlDoc.DocumentElement.InnerText + ")<br />";
            show += "<table border='1'><tr><td>測站名稱</td><td>縣市名稱</td><td>空氣品質</td><td>資料建構日期</td><td>PM2.5</td></tr>";
            XmlNodeList fnodeList = xmlDoc.DocumentElement.ChildNodes;
            for (int i = 0; i < fnodeList.Count; i++)
            {
                if (fnodeList[i].HasChildNodes)
                {
                    show += "<tr>";
                    XmlNodeList snodeList = fnodeList[i].ChildNodes;
                    //取出第一層子標籤下的子標籤(相對根表籤是第二層)(code, title, authorlist, price)
                    for (int j = 0; j < snodeList.Count; j++)
                    {
                        // show += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;+-- " + snodeList[j].Name;
                        if (snodeList[j].Name == "sitename" || snodeList[j].Name == "county" || snodeList[j].Name == "status" || snodeList[j].Name == "publishtime") show += "<td>" + snodeList[j].InnerText + "</td>";
                    }
                    for (int j = 0; j < snodeList.Count; j++)
                    {
                        if (snodeList[j].Name == "pm2.5")
                        {
                            float p = 0;
                            bool b = float.TryParse(snodeList[j].InnerText, out p);
                            // float p = float.Parse(snodeList[j]);
                            if(p<15) show += "<td>" + "<font color=\"green\">"+ p + "</font></td>";
                            else if (p < 35) show += "<td>" + "<font color=\"blue\">" + p + "</font></td>";
                            else if (p < 65) show += "<td>" + "<font color=\"orange\">" + p + "</font></td>";
                            else show += "<td>" + "<font color=\"red\">" + p + "</font></td>";  
                        }
                    }
                    show += "</tr>";
                }
            }
            show += "</table><hr />";
            show += "<hr />";
            return show;
        }

        public string DOMHW8() //還沒改，目前只改XML URI
        {
            string show = "";
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("https://udn.com/rssfeed/news/2/6638?ch=news");
            show += "<h2>資料顯示</h2><hr />channel<br/>";
            // show += xmlDoc.DocumentElement.Name + " (" + xmlDoc.DocumentElement.InnerText + ")<br />";
            // show += "<table border='1'><tr><td>測站名稱</td><td>縣市名稱</td><td>空氣品質</td><td>資料建構日期</td><td>PM2.5</td></tr>";
            XmlNodeList fnodeList = xmlDoc.DocumentElement.ChildNodes;
            for (int i = 0; i < fnodeList.Count; i++)
            {
                if (fnodeList[i].HasChildNodes)
                {
                    XmlNodeList snodeList = fnodeList[i].ChildNodes;
                    //取出第一層子標籤下的子標籤(相對根表籤是第二層)(code, title, authorlist, price)
                    for (int j = 0; j < snodeList.Count; j++)
                    {
                        // show += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;+-- " + snodeList[j].Name;
                        if (snodeList[j].Name != "item") show += snodeList[j].Name + ": " + snodeList[j].InnerText + "</br>";
                        else{
                            show += "<table border='1'>";
                            XmlNodeList snodeList_ = snodeList[j].ChildNodes;
                            for(int k=0; k< snodeList_.Count; k++) show += "<tr><td>" + snodeList_[k].InnerText + "</td></tr>";
                            show += "</table><hr />";
                        }
                    }
                }
            }
            show += "<hr />";
            return show;
        }
    }
}