using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using VkWorkspace.Messenger.Http.Models;

namespace VkWorkspace.Messenger.Http.Messages
{
    public class SelfResponse : Response
    {
        /// <summary>
        /// Уникальный идентификатор
        /// </summary>
        [JsonPropertyName("userId")]
        public string UserId { get; set; }

        /// <summary>
        /// Уникальный ник
        /// </summary>
        [JsonPropertyName("nick")]
        public string Nick { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }

        /// <summary>
        /// Описание бота
        /// </summary>
        [JsonPropertyName("about")]
        public string About { get; set; }

        /// <summary>
        /// Фото бота
        /// </summary>
        [JsonPropertyName("photo")]
        public Photo Photo { get; set; }
    }
}
