using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadePatternExample
{
    //Facade
    public class MuesliMaker
    {
        private ProductsController products;
        private PrepareController preparation;
        private ServeController serving;

        public MuesliMaker()
        {
            this.products = new ProductsController();
            this.preparation = new PrepareController();
            this.serving = new ServeController();
        }

        public void MakeMuesli()
        {
            this.products.GetProducts();
            this.preparation.PutProducts();
            this.preparation.MixProducts();
            this.serving.ServeMeal();
        }

    }
}
