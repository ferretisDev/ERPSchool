using ERPSchool.IManager;
using ERPSchool.IRepository;
using ERPSchool.Models;
using ERPSchool.ViewModels;

namespace ERPSchool.Manager
{
    public class SexManager: BaseManager<SexViewModel, Sex>, ISexManager
    {
        public SexManager(ISexRepository repository) : base(repository) { }

        public override Sex AddConverter(SexViewModel viewModel)
        {
            return new Sex()
            {
                Name = viewModel.Name
            };
        }

        public override Sex UpdatedConverter(SexViewModel viewModel, Sex entity)
        {
           entity.Name = viewModel.Name;

            return entity;
        }

        public override SexViewModel SingleConverter(Sex entity)
        {
            return new SexViewModel()
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        public override List<SexViewModel> CollectionConverter(List<Sex> entities)
        {
            return entities.Select(p => new SexViewModel()
            {
                Id=p.Id,
                Name = p.Name
            }).ToList();
        }
    }
}
