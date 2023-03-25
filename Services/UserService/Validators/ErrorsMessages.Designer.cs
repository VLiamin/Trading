﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UserService.Validators {
    using System;
    
    
    /// <summary>
    ///   Класс ресурса со строгой типизацией для поиска локализованных строк и т.д.
    /// </summary>
    // Этот класс создан автоматически классом StronglyTypedResourceBuilder
    // с помощью такого средства, как ResGen или Visual Studio.
    // Чтобы добавить или удалить член, измените файл .ResX и снова запустите ResGen
    // с параметром /str или перестройте свой проект VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class ErrorsMessages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ErrorsMessages() {
        }
        
        /// <summary>
        ///   Возвращает кэшированный экземпляр ResourceManager, использованный этим классом.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("UserService.Validators.ErrorsMessages", typeof(ErrorsMessages).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Перезаписывает свойство CurrentUICulture текущего потока для всех
        ///   обращений к ресурсу с помощью этого класса ресурса со строгой типизацией.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Avatar extension has not correct value.
        /// </summary>
        public static string AvatarExtensionNotCorrect {
            get {
                return ResourceManager.GetString("AvatarExtensionNotCorrect", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Avatar extension  is null but avatar isn&apos;t null.
        /// </summary>
        public static string AvatarExtensionNullAvatarNotNull {
            get {
                return ResourceManager.GetString("AvatarExtensionNullAvatarNotNull", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Avatar is null but avatar extension isn&apos;t null.
        /// </summary>
        public static string AvatarNullAvatarExtensionNotNull {
            get {
                return ResourceManager.GetString("AvatarNullAvatarExtensionNotNull", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Image size is more than 2 mb.
        /// </summary>
        public static string AvatarTooBig {
            get {
                return ResourceManager.GetString("AvatarTooBig", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Birthday must not be empty..
        /// </summary>
        public static string BirthdayEmpty {
            get {
                return ResourceManager.GetString("BirthdayEmpty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на You are too young.
        /// </summary>
        public static string BirthdayYoung {
            get {
                return ResourceManager.GetString("BirthdayYoung", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Email must not be empty..
        /// </summary>
        public static string EmailEmpty {
            get {
                return ResourceManager.GetString("EmailEmpty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Login length up to 50 characters.
        /// </summary>
        public static string EmailTooLong {
            get {
                return ResourceManager.GetString("EmailTooLong", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Password must not be empty..
        /// </summary>
        public static string EmptyPassword {
            get {
                return ResourceManager.GetString("EmptyPassword", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на First name must not be empty..
        /// </summary>
        public static string FirstNameEmpty {
            get {
                return ResourceManager.GetString("FirstNameEmpty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на The first letter must be uppercase and the rest must be lowercase. First name must contain only letters..
        /// </summary>
        public static string FirstNameError {
            get {
                return ResourceManager.GetString("FirstNameError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на First name is too long.
        /// </summary>
        public static string FirstNameTooLong {
            get {
                return ResourceManager.GetString("FirstNameTooLong", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на First name is too short.
        /// </summary>
        public static string FirstNameTooShort {
            get {
                return ResourceManager.GetString("FirstNameTooShort", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Id is null or empty.
        /// </summary>
        public static string IdIsNullOrEmpty {
            get {
                return ResourceManager.GetString("IdIsNullOrEmpty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Email address must be in valid format..
        /// </summary>
        public static string InvalidEmail {
            get {
                return ResourceManager.GetString("InvalidEmail", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Last name must not be empty..
        /// </summary>
        public static string LastNameEmpty {
            get {
                return ResourceManager.GetString("LastNameEmpty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на The first letter must be uppercase and the rest must be lowercase. Last name must contain only letters.
        /// </summary>
        public static string LastNameError {
            get {
                return ResourceManager.GetString("LastNameError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Last name is too long.
        /// </summary>
        public static string LastNameTooLong {
            get {
                return ResourceManager.GetString("LastNameTooLong", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Last name is too short.
        /// </summary>
        public static string LastNameTooShort {
            get {
                return ResourceManager.GetString("LastNameTooShort", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Old and new passwords are equal.
        /// </summary>
        public static string OldAndNewPasswordsEqual {
            get {
                return ResourceManager.GetString("OldAndNewPasswordsEqual", resourceCulture);
            }
        }
    }
}
