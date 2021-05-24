using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delicious.Feature.Navigation.Models
{
  public class Footer
  {
    public string FooterTextLeft { get; set; }
    public string FooterLinkUrlLeft { get; set; }
    public string FooterLinkTextLeft { get; set; }
    public string FooterLinkTargetLeft { get; set; }
    public string FooterTextRight { get; set; }
    public string FooterLinkUrlRight { get; set; }
    public string FooterLinkTextRight { get; set; }
    public string FooterLinkTargetRight { get; set; }
    public string ImageUrl { get; internal set; }
    public string ImageAlt { get; internal set; }
    public string HomeLinkUrl { get; internal set; }
  }
}
