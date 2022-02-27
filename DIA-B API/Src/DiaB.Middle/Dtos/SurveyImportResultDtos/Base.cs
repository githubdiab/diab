using CpTech.Core.Middle.Dtos;

namespace DiaB.Middle.Dtos.SurveyImportResultDtos
{
    public partial class SurveyImportResultDtos
    {
        public partial class AppFilter : PagingFilterDto
        {
        }

        public partial class Filter : CoreFilterDto
        {
        }

        public partial class AppItem : BaseItemDto
        {
        }

        public partial class Item : CoreItemDto
        {
        }

        public partial class View : Item
        {
        }

        public partial class Insert : CoreInsertDto
        {
        }

        public partial class Update : CoreUpdateDto
        {
        }
    }
}
