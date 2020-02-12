using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminCampana_2020.Domain
{
    public class PersonaDomainModel
    {
        public int Id { get; set; }
        public string StrNombre { get; set; }
        public string StrApellidoPaterno { get; set; }
        public string StrApellidoMaterno{ get; set; }
        public string StrEmail { get; set; }
        public string StrObservaciones { get; set; }
        public DireccionDomainModel DireccionDomainModel { get; set; }
        public TelefonoDomainModel TelefonoDomainModel { get; set; }
        public EstrategiaDomainModel EstrategiaDomainModel { get; set; }
    }
}
