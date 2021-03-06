﻿using System.Collections.Generic;
using AmplaTools.ProjectCreate.Framework;

namespace AmplaTools.ProjectCreate.Validation
{
    public class NameIsSpecifiedValidation : ItemValidation
    {
        public NameIsSpecifiedValidation(IValidationMessages validationMessages) : base(validationMessages)
        {
        }

        protected override List<ValidationMessage> OnValidate(IItem item)
        {
            List<ValidationMessage> messages = new List<ValidationMessage>();
            string name = item.Name;

            if (string.IsNullOrEmpty(name))
            {
                messages.Add(new ValidationMessage("Name: is not specified"));
            }
            return messages;
        }
    }

}