using System;
using System.Collections.Generic;
using System.Text;

namespace AzureFunctionsOpenAPIDemo
{
    /// <summary>
    /// Web config.
    /// </summary>
    /// <security type="http" name="http-bearer">
    ///     <description>Test security</description>
    ///     <scheme>bearer</scheme>
    ///     <bearerFormat>JWT</bearerFormat>
    /// </security>
    /// <security type="oauth2" name="oauth">
    ///     <description>Test security</description>
    ///     <flow type="implicit">
    ///         <authorizationUrl>https://example.com/api/oauth/dialog</authorizationUrl>
    ///         <refreshUrl>https://example.com/api/oauth/dialog</refreshUrl>
    ///         <scope name="scope1">
    ///             <description>scope1</description>
    ///         </scope>
    ///     </flow>
    ///     <flow type="password">
    ///         <tokenUrl>https://example.com/api/oauth/dialog</tokenUrl>
    ///         <refreshUrl>https://example.com/api/oauth/dialog</refreshUrl>
    ///         <scope name="scope1">
    ///             <description>scope1</description>
    ///         </scope>
    ///     </flow>
    ///     <flow type="authorizationCode">
    ///         <authorizationUrl>https://example.com/api/oauth/dialog</authorizationUrl>
    ///         <tokenUrl>https://example.com/api/oauth/dialog</tokenUrl>
    ///         <refreshUrl>https://example.com/api/oauth/dialog</refreshUrl>
    ///         <scope name="scope1">
    ///             <description>scope1</description>
    ///         </scope>
    ///     </flow>
    ///     <flow type="clientCredentials">
    ///         <tokenUrl>https://example.com/api/oauth/dialog</tokenUrl>
    ///         <refreshUrl>https://example.com/api/oauth/dialog</refreshUrl>
    ///         <scope name="scope1">
    ///             <description>scope1</description>
    ///         </scope>
    ///     </flow>
    /// </security>
    /// <security type="openIdConnect" name="openIdConnect">
    ///     <description>Test security</description>
    ///     <openIdConnectUrl>https://example.com/api/oauth/dialog</openIdConnectUrl>
    ///     <scope name="scope1">
    ///         <description>Scope 1 description</description>    
    ///     </scope>
    ///     <scope name="scope2">
    ///         <description>Scope 2 description</description>    
    ///     </scope>
    /// </security>
    public class Security
    {
    }
}
