using System;
using Microsoft.Reporting.WebForms;
using Ninject;
using SoftSize.Ieed.UI.App_Start;
using SoftSize.Ieed.UI.IEEDDataSetTableAdapters;
using SoftSize.Ieed.ViewModels.ServiceInterfaces;

namespace SoftSize.Ieed.UI
{
    public partial class FluxoDeCaixa : System.Web.UI.Page
    {
        [Inject]
        public ILancamentoServiceApplication LancamentoServiceApplication { get; set; }

        [Inject]
        public IAssociadoServiceApplication AssociadoServiceApplication { get; set; }

        public FluxoDeCaixa()
        {
            NinjectMVC3.bootstrapper.Kernel.Inject(this);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                IEEDDataSetTableAdapters.PR_FLUXO_CAIXATableAdapter da = new PR_FLUXO_CAIXATableAdapter();
                IEEDDataSet.PR_FLUXO_CAIXADataTable dt = new IEEDDataSet.PR_FLUXO_CAIXADataTable();
                da.Fill(dt, null, 1, 2012);


                ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource
                                                              {
                                                                  Name = "DataSet1",
                                                                  Value = dt
                                                              });
                ReportViewer1.DataBind();

                //ReportViewer1.LocalReport.ReportPath = @"Reports\FluxoDeCaixa.rdlc";
                //IEEDDataSet.MovimentoDeCaixaDataTable movimentoDeCaixaDataTable =
                //    new IEEDDataSet.MovimentoDeCaixaDataTable();
                //MovimentoDeCaixaTableAdapter movimentoDeCaixaTableAdapter =
                //    new MovimentoDeCaixaTableAdapter();
                //movimentoDeCaixaTableAdapter.Fill(movimentoDeCaixaDataTable);

                //var reportViewer = new ReportViewer();
                //reportViewer.Visible = true;
                ////reportViewer.ProcessingMode = ProcessingMode.Remote;
                //ReportViewer1.Width = new Unit(100, UnitType.Percentage);
                //ReportViewer1.Height = new Unit(100, UnitType.Percentage);
                //ReportViewer1.Style.Add("width", "100%");
                //ReportViewer1.Style.Add("height", "100%");
                //ReportViewer1.ZoomPercent = 100;
                //ReportViewer1.AsyncRendering = true;
                //ReportViewer1.ShowDocumentMapButton = true;
                //ReportViewer1.DocumentMapCollapsed = false;
                //ReportViewer1.SizeToReportContent = true;
                //ReportViewer1.ShowToolBar = true;
                //ReportViewer1.LocalReport.ReportPath = @"C:\ProjetosPessoais\SoftSize.Ieed\src\SoftSize.Ieed.UI\Reports\FluxoDeCaixa.rdlc";
                //ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource
                //                                              {
                //                                                  Name = "DsFluxoDeCaixa",
                //                                                  Value = movimentoDeCaixaDataTable
                //                                              });
                //ReportViewer1.ProcessingMode = ProcessingMode.Local;
                //string deviceInfo =
                //                "<DeviceInfo><Toolbar>false</Toolbar><HTMLFragment>true</HTMLFragment><StyleStream>false</StyleStream><Zoom>90</Zoom><DocMap>false</DocMap><JavaScript>false</JavaScript></DeviceInfo>";
                //var formatoReport = "HTML4.0";
                //string mimeType;
                //string encoding;
                //string fileNameExtension;
                //Warning[] warnings;
                //string[] streamids;

                //ReportViewer1.DataBind();

                //byte[] exportBytes = ReportViewer1.LocalReport.Render(formatoReport, deviceInfo, out mimeType, out encoding, out fileNameExtension, out streamids, out warnings);
                //HttpContext.Current.Response.AddHeader("content-disposition", "attachment; filename=ExportedReport." + fileNameExtension);
                //var buffer = System.Text.Encoding.UTF8.GetString(exportBytes);
                //Response.BinaryWrite(exportBytes);
            }
        }
    }
}