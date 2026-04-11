using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using System.Xml;

namespace VkWorkspace.Messenger.Http.Models.Buttons;

[JsonDerivedType(typeof(CallbackButton))]
[JsonDerivedType(typeof(UrlButton))]
public interface IButton;