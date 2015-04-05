using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Entities
{
    public class SystemSetting : Entity
    {
        public SystemSetting()
        {
            this.Value = string.Empty;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string DisplayName { get; set; }

        public string Group { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập giá trị")]
        public string Value { get; set; }
    }
}
