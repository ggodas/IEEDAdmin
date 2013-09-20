using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;
using SoftSize.Ieed.ViewModels.ServiceInterfaces;
using SoftSize.Ieed.ViewModels.ViewModels;

namespace SoftSize.Ieed.ServiceApplication
{
  public class DynamicViewServiceApplication : IDynamicViewServiceApplication
  {
      private string xmlPath;
      public DynamicViewServiceApplication(string xmlPath)
      {
          this.xmlPath = xmlPath;
      }
        protected IEnumerable<T> DeserializeMany<T>()
        {
            var descendentNodeName = typeof(T).Name;
            var serializer = new XmlSerializer(typeof(T));

            return
                XDocument.Load(xmlPath)
                    .Descendants(descendentNodeName)
                    .Select(descendant => (T)serializer.Deserialize(descendant.CreateReader()));
        }


        public DynamicView RecuperarViewPor(Guid id)
        {
            return DeserializeMany<DynamicView>().First(view => view.Id == id);
        }
    }
}
