﻿/// Copyright (C) 2012-2014 Soomla Inc.
///
/// Licensed under the Apache License, Version 2.0 (the "License");
/// you may not use this file except in compliance with the License.
/// You may obtain a copy of the License at
///
///      http://www.apache.org/licenses/LICENSE-2.0
///
/// Unless required by applicable law or agreed to in writing, software
/// distributed under the License is distributed on an "AS IS" BASIS,
/// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
/// See the License for the specific language governing permissions and
/// limitations under the License.

using UnityEngine;
using System;
using System.Runtime.InteropServices;

namespace Soomla {

	public static class SoomlaAndroid {
#if UNITY_ANDROID && !UNITY_EDITOR
		public static bool Initialize() {
			AndroidJNI.PushLocalFrame(100);
			using(AndroidJavaClass jniSoomlaClass = new AndroidJavaClass("com.soomla.Soomla")) {
				jniSoomlaClass.CallStatic("initialize", CoreSettings.SoomlaSecret);
			}
			//init EventHandler
			using(AndroidJavaClass jniEventHandler = new AndroidJavaClass("com.soomla.unity.SoomlaEventHandler")) {
				jniEventHandler.CallStatic("initialize");
			}
			AndroidJNI.PopLocalFrame(IntPtr.Zero);
			return true;
		}
#endif
	}
}
