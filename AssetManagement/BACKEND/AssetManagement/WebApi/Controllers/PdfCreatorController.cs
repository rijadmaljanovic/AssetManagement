using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Utility;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PdfCreatorController : ControllerBase
    {
        private IConverter _converter;
        public readonly ITemplateGenerator templateGenerator;
        public PdfCreatorController(IConverter converter, ITemplateGenerator templateGenerator)
        {
            _converter = converter;
            this.templateGenerator = templateGenerator;
        }
        [HttpGet("getAssetsReportPDF")]
        public IActionResult Assets()
        {
            string fileName = "Assets" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".pdf";
            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Landscape,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 10 },
                DocumentTitle = "Assets",
                Out=Path.Combine(Directory.GetCurrentDirectory(),"Exports",fileName)
            };
            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = templateGenerator.HTMLStringAssets(),
                WebSettings = { DefaultEncoding = "utf-8"},
                HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Page [page] of [toPage]", Line = true },
                FooterSettings = { FontName = "Arial", FontSize = 9, Line = true, Center = "" }
            };
            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };
            _converter.Convert(pdf);
            PdfFile pdfFile = new PdfFile() { FileName = $"Files/{fileName}" };
            string json=JsonConvert.SerializeObject(pdfFile);
            return Ok(json);
        }

        [HttpGet("getVendorsReportPDF")]
        public IActionResult Vendors()
        {
            string fileName = "Vendors"+DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss")+".pdf";
            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 10 },
                DocumentTitle = "Assets",
                Out = Path.Combine(Directory.GetCurrentDirectory(), "Exports", fileName)
            };
            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = templateGenerator.HTMLStringVendors(),
                WebSettings = { DefaultEncoding = "utf-8"},
                HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Page [page] of [toPage]", Line = true },
                FooterSettings = { FontName = "Arial", FontSize = 9, Line = true, Center = "" }
            };
            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };
            _converter.Convert(pdf);
            PdfFile pdfFile = new PdfFile() { FileName = $"Files/{fileName}" };
            string json = JsonConvert.SerializeObject(pdfFile);
            return Ok(json);
        }

        [HttpGet("getAssignedAssetsReportPDF")]
        public IActionResult AssignedAssets()
        {
            string fileName = "AssignedAssets" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".pdf";
            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 10 },
                DocumentTitle = "Assigned assets",
                Out = Path.Combine(Directory.GetCurrentDirectory(), "Exports", fileName)
            };
            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = templateGenerator.HTMLStringAssignedAssets(),
                WebSettings = { DefaultEncoding = "utf-8" },
                HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Page [page] of [toPage]", Line = true },
                FooterSettings = { FontName = "Arial", FontSize = 9, Line = true, Center = "" }
            };
            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };
            _converter.Convert(pdf);
            PdfFile pdfFile = new PdfFile() { FileName = $"Files/{fileName}" };
            string json = JsonConvert.SerializeObject(pdfFile);
            return Ok(json);
        }

        [HttpGet("getOfficeLocationsReportPDF")]
        public IActionResult Locations()
        {
            string fileName = "OfficeLocations" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".pdf";
            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 10 },
                DocumentTitle = "Office locations",
                Out = Path.Combine(Directory.GetCurrentDirectory(), "Exports", fileName)
            };
            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = templateGenerator.HTMLStringLocations(),
                WebSettings = { DefaultEncoding = "utf-8"},
                HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Page [page] of [toPage]", Line = true },
                FooterSettings = { FontName = "Arial", FontSize = 9, Line = true, Center = "" }
            };
            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };
            _converter.Convert(pdf);
            PdfFile pdfFile = new PdfFile() { FileName = $"Files/{fileName}" };
            string json = JsonConvert.SerializeObject(pdfFile);
            return Ok(json);
        }

        [HttpGet("getManufacturersReportPDF")]
        public IActionResult Manufacturers()
        {
            string fileName = "Manufacturers" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".pdf";
            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 10 },
                DocumentTitle = "Manufacturers",
                Out = Path.Combine(Directory.GetCurrentDirectory(), "Exports", fileName)
            };
            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = templateGenerator.HTMLStringManufacturers(),
                WebSettings = { DefaultEncoding = "utf-8"},
                HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Page [page] of [toPage]", Line = true },
                FooterSettings = { FontName = "Arial", FontSize = 9, Line = true, Center = "" }
            };
            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };
            _converter.Convert(pdf);
            PdfFile pdfFile = new PdfFile() { FileName = $"Files/{fileName}" };
            string json = JsonConvert.SerializeObject(pdfFile);
            return Ok(json);
        }

        [HttpGet("getEmployeesReportPDF")]
        public IActionResult Employees()
        {
            string fileName = "Employees" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".pdf";
            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 10 },
                DocumentTitle = "Employees",
                Out = Path.Combine(Directory.GetCurrentDirectory(), "Exports", fileName)
            };
            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = templateGenerator.HTMLStringEmployees(),
                WebSettings = { DefaultEncoding = "utf-8"},
                HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Page [page] of [toPage]", Line = true },
                FooterSettings = { FontName = "Arial", FontSize = 9, Line = true, Center = "" }
            };
            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };
            _converter.Convert(pdf);
            PdfFile pdfFile = new PdfFile() { FileName = $"Files/{fileName}" };
            string json = JsonConvert.SerializeObject(pdfFile);
            return Ok(json);
        }

        [HttpGet("getProductTypesReportPDF")]
        public IActionResult ProductTypes()
        {
            string fileName = "ProductTypes" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".pdf";
            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 10 },
                DocumentTitle = "ProductTypes",
                Out = Path.Combine(Directory.GetCurrentDirectory(), "Exports", fileName)
            };
            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = templateGenerator.HTMLStringProductType(),
                WebSettings = { DefaultEncoding = "utf-8"},
                HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Page [page] of [toPage]", Line = true },
                FooterSettings = { FontName = "Arial", FontSize = 9, Line = true, Center = "" }
            };
            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };
            _converter.Convert(pdf);
            PdfFile pdfFile = new PdfFile() { FileName = $"Files/{fileName}" };
            string json = JsonConvert.SerializeObject(pdfFile);
            return Ok(json);
        }

        [HttpGet("getDepartmentsPDF")]
        public IActionResult Departments()
        {
            string fileName = "Departments" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".pdf";
            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 10 },
                DocumentTitle = "Departments",
                Out = Path.Combine(Directory.GetCurrentDirectory(), "Exports", fileName)
            };
            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = templateGenerator.HTMLStringDepartment(),
                WebSettings = { DefaultEncoding = "utf-8"},
                HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Page [page] of [toPage]", Line = true },
                FooterSettings = { FontName = "Arial", FontSize = 9, Line = true, Center = "" }
            };
            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };
            _converter.Convert(pdf);
            PdfFile pdfFile = new PdfFile() { FileName = $"Files/{fileName}" };
            string json = JsonConvert.SerializeObject(pdfFile);
            return Ok(json);
        }

        [HttpGet("getProductsPDF")]
        public IActionResult Products()
        {
            string fileName = "Products" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".pdf";
            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 10 },
                DocumentTitle = "Products",
                Out = Path.Combine(Directory.GetCurrentDirectory(), "Exports", fileName)
            };
            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = templateGenerator.HTMLStringProducts(),
                WebSettings = { DefaultEncoding = "utf-8"},
                HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Page [page] of [toPage]", Line = true },
                FooterSettings = { FontName = "Arial", FontSize = 9, Line = true, Center = "" }
            };
            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };
            _converter.Convert(pdf);
            PdfFile pdfFile = new PdfFile() { FileName = $"Files/{fileName}" };
            string json = JsonConvert.SerializeObject(pdfFile);
            return Ok(json);
        }
    }
}
