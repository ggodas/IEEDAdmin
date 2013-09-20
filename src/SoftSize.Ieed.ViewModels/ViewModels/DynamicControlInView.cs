using System.Collections.Generic;

namespace SoftSize.Ieed.ViewModels.ViewModels
{
    public class DynamicControlInView
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Label { get; set; }
        public string TemplateControl { get; set; }
        public string CssClass { get; set; }
        public bool IsRequired { get; set; }
        public string ErrorMessage { get; set; }
        public List<string> Attributes { get; set; }
        public List<Option> OptionList { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
        public bool Checked { get; set; }
        public string Script { get; set; }
        public bool Multiple { get; set; }
        public List<string> ExibirSomenteParaOsPerfis { get; set; }
    }

    public class Option
    {
        public string Value { get; set; }
        public string Text { get; set; }
        public bool Selected { get; set; }
    }
}
