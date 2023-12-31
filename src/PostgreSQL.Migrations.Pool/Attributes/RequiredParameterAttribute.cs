﻿using Swashbuckle.AspNetCore.Annotations;

namespace PostgreSQL.Migrations.Pool.Attributes {

    /// <summary>
    /// Shortcut for swagger required parameters.
    /// </summary>
    public class RequiredParameterAttribute : SwaggerParameterAttribute {

        public RequiredParameterAttribute ( string description = "" ) : base ( description ) {
            Required = true;
        }

    }

}
