namespace Business.Services.Interfaces
{
    public interface IGenericPassService
    {
        /// <summary>
        /// Create authenticated service client using a service account file.
        /// </summary>
        void Auth();

        /// <summary>
        /// Create a class.
        /// </summary>
        /// <param name="issuerId">The issuer ID being used for this request.</param>
        /// <param name="classSuffix">Developer-defined unique ID for this pass class.</param>
        /// <returns>The pass class ID: "{issuerId}.{classSuffix}"</returns>
        string CreateClass(string issuerId, string classSuffix);

        /// <summary>
        /// Update a class.
        /// <para />
        /// <strong>Warning:</strong> This replaces all existing class attributes!
        /// </summary>
        /// <param name="issuerId">The issuer ID being used for this request.</param>
        /// <param name="classSuffix">Developer-defined unique ID for this pass class.</param>
        /// <returns>The pass class ID: "{issuerId}.{classSuffix}"</returns>
        string UpdateClass(string issuerId, string classSuffix);

        /// <summary>
        /// Patch a class.
        /// <para />
        /// The PATCH method supports patch semantics.
        /// </summary>
        /// <param name="issuerId">The issuer ID being used for this request.</param>
        /// <param name="classSuffix">Developer-defined unique ID for this pass class.</param>
        /// <returns>The pass class ID: "{issuerId}.{classSuffix}"</returns>
        string PatchClass(string issuerId, string classSuffix);

        /// <summary>
        /// Create an object.
        /// </summary>
        /// <param name="issuerId">The issuer ID being used for this request.</param>
        /// <param name="classSuffix">Developer-defined unique ID for this pass class.</param>
        /// <param name="objectSuffix">Developer-defined unique ID for this pass object.</param>
        /// <returns>The pass object ID: "{issuerId}.{objectSuffix}"</returns>
        string CreateObject(string issuerId, string classSuffix, string objectSuffix);

        /// <summary>
        /// Update an object.
        /// <para />
        /// <strong>Warning:</strong> This replaces all existing class attributes!
        /// </summary>
        /// <param name="issuerId">The issuer ID being used for this request.</param>
        /// <param name="objectSuffix">Developer-defined unique ID for this pass object.</param>
        /// <returns>The pass object ID: "{issuerId}.{objectSuffix}"</returns>
        string UpdateObject(string issuerId, string objectSuffix);

        /// <summary>
        /// Patch an object.
        /// </summary>
        /// <param name="issuerId">The issuer ID being used for this request.</param>
        /// <param name="objectSuffix">Developer-defined unique ID for this pass object.</param>
        /// <returns>The pass object ID: "{issuerId}.{objectSuffix}"</returns>
        string PatchObject(string issuerId, string objectSuffix);

        /// <summary>
        /// Expire an object.
        /// <para />
        /// Sets the object's state to Expired. If the valid time interval is already
        /// set, the pass will expire automatically up to 24 hours after.
        /// </summary>
        /// <param name="issuerId">The issuer ID being used for this request.</param>
        /// <param name="objectSuffix">Developer-defined unique ID for this pass object.</param>
        /// <returns>The pass object ID: "{issuerId}.{objectSuffix}"</returns>
        string ExpireObject(string issuerId, string objectSuffix);

        /// <summary>
        /// Generate a signed JWT that creates a new pass class and object.
        /// <para />
        /// When the user opens the "Add to Google Wallet" URL and saves the pass to
        /// their wallet, the pass class and object defined in the JWT are created.
        /// This allows you to create multiple pass classes and objects in one API
        /// call when the user saves the pass to their wallet.
        /// <para />
        /// The Google Wallet C# library uses Newtonsoft.Json.JsonPropertyAttribute
        /// to specify the property names when converting objects to JSON. The
        /// Newtonsoft.Json.JsonConvert.SerializeObject method will automatically
        /// serialize the object with the right property names.
        /// </summary>
        /// <param name="issuerId">The issuer ID being used for this request.</param>
        /// <param name="classSuffix">Developer-defined unique ID for this pass class.</param>
        /// <param name="objectSuffix">Developer-defined unique ID for the pass object.</param>
        /// <returns>An "Add to Google Wallet" link.</returns>
        string CreateJWTNewObjects(string issuerId, string classSuffix, string objectSuffix);

        /// <summary>
        /// Generate a signed JWT that references an existing pass object.
        /// <para />
        /// When the user opens the "Add to Google Wallet" URL and saves the pass to
        /// their wallet, the pass objects defined in the JWT are added to the user's
        /// Google Wallet app. This allows the user to save multiple pass objects in
        /// one API call.
        /// <para />
        /// The objects to add must follow the below format:
        /// <para />
        /// { 'id': 'ISSUER_ID.OBJECT_SUFFIX', 'classId': 'ISSUER_ID.CLASS_SUFFIX' }
        /// <para />
        /// The Google Wallet C# library uses Newtonsoft.Json.JsonPropertyAttribute
        /// to specify the property names when converting objects to JSON. The
        /// Newtonsoft.Json.JsonConvert.SerializeObject method will automatically
        /// serialize the object with the right property names.
        /// </summary>
        /// <param name="issuerId">The issuer ID being used for this request.</param>
        /// <returns>An "Add to Google Wallet" link.</returns>
        string CreateJWTExistingObjects(string issuerId);

        /// <summary>
        /// Batch create Google Wallet objects from an existing class.
        /// </summary>
        /// <param name="issuerId">The issuer ID being used for this request.</param>
        /// <param name="classSuffix">Developer-defined unique ID for this pass class.</param>
        void BatchCreateObjects(string issuerId, string classSuffix);
    }
}
