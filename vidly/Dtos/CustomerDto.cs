﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using vidly.Models;

namespace vidly.Dtos
{
    public class CustomerDto
    {

        public int Id { get; set; }


        [Required(ErrorMessage = "Please enter customer's name")]
        [StringLength(255)]
        public string Name { get; set; }


        public bool isSubscribedToNewsLetter { get; set; }


        public byte MembershipTypeId { get; set; }

        public MembershipTypeDto MembershipType { get; set; }


        public DateTime? BirthDate { get; set; }


    }
}