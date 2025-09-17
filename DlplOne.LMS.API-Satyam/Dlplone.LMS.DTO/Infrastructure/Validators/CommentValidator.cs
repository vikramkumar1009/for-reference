using FluentValidation;
using Dlplone.LMS.DTO.NRLHealth;
using System.Text.RegularExpressions;
using System.Xml;

namespace Dlplone.LMS.DTO.Infrastructure.Validators
{
    public class CommentValidator : AbstractValidator<NRLHealth.NRLCommentDto>
    {
        public CommentValidator()
        {
            RuleFor(x => x.Comment).NotEmpty().WithMessage("Comment Should  be valid");
            When(x => !string.IsNullOrEmpty(x.Comment), () =>
                {
                    RuleFor(x => x.Comment).Must(x => CheckHTMLForText(x)).WithMessage("Comment Should  be valid");
                });
           
        }


            public static bool CheckHTMLForText(string html)
            {
            if (string.IsNullOrEmpty(html))
                return false;
            else
            {
                Regex regJs = new Regex(@"(?s)<\s?script.*?(/\s?>|<\s?/\s?script\s?>)", RegexOptions.IgnoreCase);
                Regex reg = new Regex("<[^>]+>", RegexOptions.IgnoreCase);
                var validHtml =  !reg.IsMatch(html) && !regJs.IsMatch(html);
                return validHtml;
            }
        }
        }
}
