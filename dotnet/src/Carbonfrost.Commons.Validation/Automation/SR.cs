
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

  /// <summary>The property initialization for the validator cannot specify properties that are missing or are marked as obsolete or preliminary with an error status: ${errorProperty}.</summary>
    internal static string CannotUseMissingOrErrorProperties(
    object @errorProperty
    ) {
        return string.Format(Culture, ResourceFinder("CannotUseMissingOrErrorProperties") , @errorProperty);
    }

  /// <summary>The value of the field, '${fieldName}', is not accessible.</summary>
    internal static string FieldValueNotAccessible(
    object @fieldName
    ) {
        return string.Format(Culture, ResourceFinder("FieldValueNotAccessible") , @fieldName);
    }

  /// <summary>The return value for the method is either not accessible or this method is not eligible for validation: `${methodName}'.</summary>
    internal static string MethodReturnValueNotAccessible(
    object @methodName
    ) {
        return string.Format(Culture, ResourceFinder("MethodReturnValueNotAccessible") , @methodName);
    }

  /// <summary>The target is not a dictionary type and is not able to be treated like one.</summary>
    internal static string NotDictionaryType(
    
    ) {
        return string.Format(Culture, ResourceFinder("NotDictionaryType") );
    }

  /// <summary>The value of the property, `${propertyName}', is not accessible.</summary>
    internal static string PropertyValueNotAccessible(
    object @propertyName
    ) {
        return string.Format(Culture, ResourceFinder("PropertyValueNotAccessible") , @propertyName);
    }

  /// <summary>The value does not match the required pattern.</summary>
    internal static string RegexValidatorDefaultMessage(
    
    ) {
        return string.Format(Culture, ResourceFinder("RegexValidatorDefaultMessage") );
    }

  /// <summary>Self-validation of the instance failed.</summary>
    internal static string SelfValidationFailed(
    
    ) {
        return string.Format(Culture, ResourceFinder("SelfValidationFailed") );
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

  /// <summary>The text must be a minimum of ${minCharCount} and a maximum of ${maxCharCount} characters in length.</summary>
    internal static string ValidatorLengthMessageBetween(
    object @minCharCount, object @maxCharCount
    ) {
        return string.Format(Culture, ResourceFinder("ValidatorLengthMessageBetween") , @minCharCount, @maxCharCount);
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

  /// <summary>{{Key}} is required.</summary>
    internal static string ValidatorRequiredMessageWithKey(
    
    ) {
        return string.Format(Culture, ResourceFinder("ValidatorRequiredMessageWithKey") );
    }

    }
}
