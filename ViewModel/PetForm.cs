using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using static IO.Swagger.Models.Pet;

namespace AzureFunctionsOpenAPIDemo.ViewModel
{

    /// <summary>
    /// A pet ViewModel for form post
    /// </summary>
    public class PetForm
    {
        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [Required]
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// pet status in the store
        /// </summary>
        /// <value>pet status in the store</value>
        [DataMember(Name = "status")]
        public StatusEnum? Status { get; set; }
    }
}
