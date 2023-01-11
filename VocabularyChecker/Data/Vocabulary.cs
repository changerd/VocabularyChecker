using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VocabularyChecker.Data
{
    public class Vocabulary
    {
        [Key]
        public int Id { get; set; }

        public string Word { get; set; }

        public string Transaltion { get; set; }
    }
}
