
// This file was automatically generated.  DO NOT EDIT or else
// your changes could be lost!

#pragma warning disable 1570

using System;
using System.Globalization;
using System.Resources;
using System.Reflection;

namespace Carbonfrost.Commons.Validation.Resources {

    /// <summary>
    /// Contains strongly-typed string resources.
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("srgen", "1.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute]
    internal static partial class SR {

        private static global::System.Resources.ResourceManager _resources;
        private static global::System.Globalization.CultureInfo _currentCulture;
        private static global::System.Func<string, string> _resourceFinder;

        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(_resources, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Carbonfrost.Commons.Validation.Automation.SR", typeof(SR).GetTypeInfo().Assembly);
                    _resources = temp;
                }
                return _resources;
            }
        }

        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return _currentCulture;
            }
            set {
                _currentCulture = value;
            }
        }

        private static global::System.Func<string, string> ResourceFinder {
            get {
                if (object.ReferenceEquals(_resourceFinder, null)) {
                    try {
                        global::System.Resources.ResourceManager rm = ResourceManager;
                        _resourceFinder = delegate (string s) {
                            return rm.GetString(s);
                        };
                    } catch (global::System.Exception ex) {
                        _resourceFinder = delegate (string s) {
                            return string.Format("localization error! {0}: {1} ({2})", s, ex.GetType(), ex.Message);
                        };
                    }
                }
                return _resourceFinder;
            }
        }


  /// <summary>The name of an abstract type or of an interface cannot be used in the serializer unless the type exposes a type proxy mechanism which references a non-abstract, non-generic, non-array type.</summary>
    internal static string AbstractTypesNotSupported(

    ) {
        return string.Format(Culture, ResourceFinder("AbstractTypesNotSupported") );
    }

  /// <summary>The attribute '${attributeName}' was either not present on the node or could not be converted to the required type, '${typeName}'.</summary>
    internal static string AttributeConversionFailed(
    object @attributeName, object @typeName
    ) {
        return string.Format(Culture, ResourceFinder("AttributeConversionFailed") , @attributeName, @typeName);
    }

  /// <summary>The parameter must reference a KnownValidator value other than KnownValidator.Unknown</summary>
    internal static string CannotBeUnknownValidator(

    ) {
        return string.Format(Culture, ResourceFinder("CannotBeUnknownValidator") );
    }

  /// <summary>A self validator cannot be created in this way.</summary>
    internal static string CannotCreateKnownValidatorThisWay(

    ) {
        return string.Format(Culture, ResourceFinder("CannotCreateKnownValidatorThisWay") );
    }

  /// <summary>The object does not support attributes.</summary>
    internal static string CannotSelectAttributes(

    ) {
        return string.Format(Culture, ResourceFinder("CannotSelectAttributes") );
    }

  /// <summary>The property `${propertyName}' cannot be set for the component because it is either read-only or the component itself is not castable or adaptable to the required interface facility, `${interfaceName}'.</summary>
    internal static string CannotSetPropertyThroughIndirection(
    object @propertyName, object @interfaceName
    ) {
        return string.Format(Culture, ResourceFinder("CannotSetPropertyThroughIndirection") , @propertyName, @interfaceName);
    }

  /// <summary>The given property, `${propertyName},' cannot be set at this time because there is no tree builder context, because the target component is not located within the hierarchy of instances currently accessible by the tree builder, or because the tree builder context has failed to supply a required service.</summary>
    internal static string CannotSetTreeBuilderPropertyNow(
    object @propertyName
    ) {
        return string.Format(Culture, ResourceFinder("CannotSetTreeBuilderPropertyNow") , @propertyName);
    }

  /// <summary>The property initialization for the validator cannot specify properties that are missing or are marked as obsolete or preliminary with an error status: ${errorProperty}.</summary>
    internal static string CannotUseMissingOrErrorProperties(
    object @errorProperty
    ) {
        return string.Format(Culture, ResourceFinder("CannotUseMissingOrErrorProperties") , @errorProperty);
    }

  /// <summary>The default document namespace is not valid for this argument.</summary>
    internal static string DefaultDocumentNamespaceNotValid(

    ) {
        return string.Format(Culture, ResourceFinder("DefaultDocumentNamespaceNotValid") );
    }

  /// <summary>The default document qualified name is not valid in this context.</summary>
    internal static string DefaultDocumentQualifiedNameNotValid(

    ) {
        return string.Format(Culture, ResourceFinder("DefaultDocumentQualifiedNameNotValid") );
    }

  /// <summary>The composite property reference '${compositePropertyReference}' contains a property name which is empty.</summary>
    internal static string EmptyPropertyNameInCompositeName(
    object @compositePropertyReference
    ) {
        return string.Format(Culture, ResourceFinder("EmptyPropertyNameInCompositeName") , @compositePropertyReference);
    }

  /// <summary>The external source '${source}' (content type: '${contentType}') could not be located or the Web client cannot provide access to this resource.</summary>
    internal static string ExternalSourceMissing(
    object @source, object @contentType
    ) {
        return string.Format(Culture, ResourceFinder("ExternalSourceMissing") , @source, @contentType);
    }

  /// <summary>The external source '${source}' (content type: '${contentType}') cannot be used here because it is annotated with '${message}'.</summary>
    internal static string ExternalSourceNotAllowedHere(
    object @source, object @contentType, object @message
    ) {
        return string.Format(Culture, ResourceFinder("ExternalSourceNotAllowedHere") , @source, @contentType, @message);
    }

  /// <summary>The value of the field, '${fieldName}', is not accessible.</summary>
    internal static string FieldValueNotAccessible(
    object @fieldName
    ) {
        return string.Format(Culture, ResourceFinder("FieldValueNotAccessible") , @fieldName);
    }

  /// <summary>An error was encountered while processing the data of the canonical document.</summary>
    internal static string GenericCanonicalDocumentExceptionMessage(

    ) {
        return string.Format(Culture, ResourceFinder("GenericCanonicalDocumentExceptionMessage") );
    }

  /// <summary>The given combination of return type and/or arguments is not supported by this instance factory.</summary>
    internal static string InstanceFactoryGenericError(

    ) {
        return string.Format(Culture, ResourceFinder("InstanceFactoryGenericError") );
    }

  /// <summary>The text does not represent a valid document qualified name.</summary>
    internal static string InvalidDocumentQualifiedName(

    ) {
        return string.Format(Culture, ResourceFinder("InvalidDocumentQualifiedName") );
    }

  /// <summary>The item is required to exist in the collection.</summary>
    internal static string ItemRequiredToExistInCollection(

    ) {
        return string.Format(Culture, ResourceFinder("ItemRequiredToExistInCollection") );
    }

  /// <summary>The given known streaming source type is not accessible because the application does not reference the dependent assembly, ${name}.</summary>
    internal static string KnownStreamingSourceIntrinsicMissing(
    object @name
    ) {
        return string.Format(Culture, ResourceFinder("KnownStreamingSourceIntrinsicMissing") , @name);
    }

  /// <summary>The return value for the method is either not accessible or this method is not eligible for validation: `${methodName}'.</summary>
    internal static string MethodReturnValueNotAccessible(
    object @methodName
    ) {
        return string.Format(Culture, ResourceFinder("MethodReturnValueNotAccessible") , @methodName);
    }

  /// <summary>A constructor with matching arguments could not be found.</summary>
    internal static string NoConstructor(

    ) {
        return string.Format(Culture, ResourceFinder("NoConstructor") );
    }

  /// <summary>The target is not a dictionary type and is not able to be treated like one.</summary>
    internal static string NotDictionaryType(

    ) {
        return string.Format(Culture, ResourceFinder("NotDictionaryType") );
    }

  /// <summary>The text for the property '${propertyName}' cannot be parsed into a valid instance of type '${typeName}'.</summary>
    internal static string ParseFailureAtProperty(
    object @propertyName, object @typeName
    ) {
        return string.Format(Culture, ResourceFinder("ParseFailureAtProperty") , @propertyName, @typeName);
    }

  /// <summary>The properties of the instance cannot be modified because the object is already in use.</summary>
    internal static string PropertiesSealedBecauseInUse(

    ) {
        return string.Format(Culture, ResourceFinder("PropertiesSealedBecauseInUse") );
    }

  /// <summary>The value of the property, `${propertyName}', is not accessible.</summary>
    internal static string PropertyValueNotAccessible(
    object @propertyName
    ) {
        return string.Format(Culture, ResourceFinder("PropertyValueNotAccessible") , @propertyName);
    }

  /// <summary>The reference '${reference}' could not be resolved.</summary>
    internal static string ReferenceMissing(
    object @reference
    ) {
        return string.Format(Culture, ResourceFinder("ReferenceMissing") , @reference);
    }

  /// <summary>The reference '${reference}' cannot be used here because it is annotated with '${usage}'.</summary>
    internal static string ReferenceNotAllowedHere(
    object @reference, object @usage
    ) {
        return string.Format(Culture, ResourceFinder("ReferenceNotAllowedHere") , @reference, @usage);
    }

  /// <summary>The value does not match the required pattern.</summary>
    internal static string RegexValidatorDefaultMessage(

    ) {
        return string.Format(Culture, ResourceFinder("RegexValidatorDefaultMessage") );
    }

  /// <summary>The value matches a pattern that is not permitted</summary>
    internal static string RegexValidatorDefaultMessageNegate(

    ) {
        return string.Format(Culture, ResourceFinder("RegexValidatorDefaultMessageNegate") );
    }

  /// <summary>Self-validation of the instance failed.</summary>
    internal static string SelfValidationFailed(

    ) {
        return string.Format(Culture, ResourceFinder("SelfValidationFailed") );
    }

  /// <summary>The type is missing or could not be loaded automatically: ${typeReferenceOrType}.</summary>
    internal static string TypeMissing(
    object @typeReferenceOrType
    ) {
        return string.Format(Culture, ResourceFinder("TypeMissing") , @typeReferenceOrType);
    }

  /// <summary>One or more validation errors occurred.</summary>
    internal static string ValidationErrorsOccurred(

    ) {
        return string.Format(Culture, ResourceFinder("ValidationErrorsOccurred") );
    }

  /// <summary>Validation is not defined for the given type.</summary>
    internal static string ValidationNotDefined(

    ) {
        return string.Format(Culture, ResourceFinder("ValidationNotDefined") );
    }

  /// <summary>Items cannot be removed or cleared from the ValidationResults, even using the interface implementation.</summary>
    internal static string ValidationResultsCannotRemove(

    ) {
        return string.Format(Culture, ResourceFinder("ValidationResultsCannotRemove") );
    }

  /// <summary>The text must be a minimum of ${minCharCount} and a maximum of ${maxCharCount} characters in length.</summary>
    internal static string ValidatorLengthMessageBetween(
    object @minCharCount, object @maxCharCount
    ) {
        return string.Format(Culture, ResourceFinder("ValidatorLengthMessageBetween") , @minCharCount, @maxCharCount);
    }

  /// <summary>The text must have fewer than ${minCharCount} characters or more than ${maxCharCount} characters in length.</summary>
    internal static string ValidatorLengthMessageBetweenNegate(
    object @minCharCount, object @maxCharCount
    ) {
        return string.Format(Culture, ResourceFinder("ValidatorLengthMessageBetweenNegate") , @minCharCount, @maxCharCount);
    }

  /// <summary>This text may have a maximum ${charCount} characters in length.</summary>
    internal static string ValidatorLengthMessageTooLong(
    object @charCount
    ) {
        return string.Format(Culture, ResourceFinder("ValidatorLengthMessageTooLong") , @charCount);
    }

  /// <summary>This text may have a minimum ${charCount} characters in length.</summary>
    internal static string ValidatorLengthMessageTooShort(
    object @charCount
    ) {
        return string.Format(Culture, ResourceFinder("ValidatorLengthMessageTooShort") , @charCount);
    }

  /// <summary>This value is required.</summary>
    internal static string ValidatorRequiredMessage(

    ) {
        return string.Format(Culture, ResourceFinder("ValidatorRequiredMessage") );
    }

  /// <summary>This text was not accepted because it was deemed to be spam.</summary>
    internal static string ValidatorSpamGuardMessage(

    ) {
        return string.Format(Culture, ResourceFinder("ValidatorSpamGuardMessage") );
    }

    }
}
