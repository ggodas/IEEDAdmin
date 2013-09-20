using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SoftSize.Ieed.ViewModels.ViewModels
{
    public class DynamicView
    {
        public DynamicView()
        {
            //Layout = "~/Views/Shared/_Layout.cshtml";
            //TitleView = "Relatório de Consumo";
            //TitleFilter = "Filtros"; 
            //ActionMethod = FormMethod.Get;
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Layout { get; set; }
        public string TitleView { get; set; }
        public string TitleFilter { get; set; }
        public string ActionName { get; set; }
        public string ControllerName { get; set; }
        public FormMethod ActionMethod { get; set; }

        private List<DynamicControlInView> controlsInView;
        public List<DynamicControlInView> ControlsInView
        {
            get { return controlsInView; }
            set { controlsInView = value; }
        }

        public void AddControlInView(DynamicControlInView dynamicControlInView)
        {
            //controlsInView.Add(dynamicControlInView);
        }
    }
}
