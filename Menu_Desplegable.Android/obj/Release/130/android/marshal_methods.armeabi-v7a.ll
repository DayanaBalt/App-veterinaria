; ModuleID = 'obj\Release\130\android\marshal_methods.armeabi-v7a.ll'
source_filename = "obj\Release\130\android\marshal_methods.armeabi-v7a.ll"
target datalayout = "e-m:e-p:32:32-Fi8-i64:64-v128:64:128-a:0:32-n32-S64"
target triple = "armv7-unknown-linux-android"


%struct.MonoImage = type opaque

%struct.MonoClass = type opaque

%struct.MarshalMethodsManagedClass = type {
	i32,; uint32_t token
	%struct.MonoClass*; MonoClass* klass
}

%struct.MarshalMethodName = type {
	i64,; uint64_t id
	i8*; char* name
}

%class._JNIEnv = type opaque

%class._jobject = type {
	i8; uint8_t b
}

%class._jclass = type {
	i8; uint8_t b
}

%class._jstring = type {
	i8; uint8_t b
}

%class._jthrowable = type {
	i8; uint8_t b
}

%class._jarray = type {
	i8; uint8_t b
}

%class._jobjectArray = type {
	i8; uint8_t b
}

%class._jbooleanArray = type {
	i8; uint8_t b
}

%class._jbyteArray = type {
	i8; uint8_t b
}

%class._jcharArray = type {
	i8; uint8_t b
}

%class._jshortArray = type {
	i8; uint8_t b
}

%class._jintArray = type {
	i8; uint8_t b
}

%class._jlongArray = type {
	i8; uint8_t b
}

%class._jfloatArray = type {
	i8; uint8_t b
}

%class._jdoubleArray = type {
	i8; uint8_t b
}

; assembly_image_cache
@assembly_image_cache = local_unnamed_addr global [0 x %struct.MonoImage*] zeroinitializer, align 4
; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = local_unnamed_addr constant [96 x i32] [
	i32 34715100, ; 0: Xamarin.Google.Guava.ListenableFuture.dll => 0x211b5dc => 44
	i32 57263871, ; 1: Xamarin.Forms.Core.dll => 0x369c6ff => 39
	i32 182336117, ; 2: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0xade3a75 => 36
	i32 230752869, ; 3: Microsoft.CSharp.dll => 0xdc10265 => 6
	i32 318968648, ; 4: Xamarin.AndroidX.Activity.dll => 0x13031348 => 20
	i32 321597661, ; 5: System.Numerics => 0x132b30dd => 17
	i32 342366114, ; 6: Xamarin.AndroidX.Lifecycle.Common => 0x146817a2 => 30
	i32 347068432, ; 7: SQLitePCLRaw.lib.e_sqlite3.android.dll => 0x14afd810 => 12
	i32 442521989, ; 8: Xamarin.Essentials => 0x1a605985 => 38
	i32 450948140, ; 9: Xamarin.AndroidX.Fragment.dll => 0x1ae0ec2c => 28
	i32 465846621, ; 10: mscorlib => 0x1bc4415d => 8
	i32 469710990, ; 11: System.dll => 0x1bff388e => 16
	i32 627609679, ; 12: Xamarin.AndroidX.CustomView => 0x2568904f => 26
	i32 748832960, ; 13: SQLitePCLRaw.batteries_v2 => 0x2ca248c0 => 10
	i32 809851609, ; 14: System.Drawing.Common.dll => 0x30455ad9 => 46
	i32 859078387, ; 15: Menu_Desplegable => 0x33347ef3 => 5
	i32 928116545, ; 16: Xamarin.Google.Guava.ListenableFuture => 0x3751ef41 => 44
	i32 967690846, ; 17: Xamarin.AndroidX.Lifecycle.Common.dll => 0x39adca5e => 30
	i32 974778368, ; 18: FormsViewGroup.dll => 0x3a19f000 => 3
	i32 1012816738, ; 19: Xamarin.AndroidX.SavedState.dll => 0x3c5e5b62 => 35
	i32 1035644815, ; 20: Xamarin.AndroidX.AppCompat => 0x3dbaaf8f => 22
	i32 1042160112, ; 21: Xamarin.Forms.Platform.dll => 0x3e1e19f0 => 41
	i32 1052210849, ; 22: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x3eb776a1 => 32
	i32 1098259244, ; 23: System => 0x41761b2c => 16
	i32 1292207520, ; 24: SQLitePCLRaw.core.dll => 0x4d0585a0 => 11
	i32 1293217323, ; 25: Xamarin.AndroidX.DrawerLayout.dll => 0x4d14ee2b => 27
	i32 1365406463, ; 26: System.ServiceModel.Internals.dll => 0x516272ff => 45
	i32 1376866003, ; 27: Xamarin.AndroidX.SavedState => 0x52114ed3 => 35
	i32 1406073936, ; 28: Xamarin.AndroidX.CoordinatorLayout => 0x53cefc50 => 24
	i32 1411638395, ; 29: System.Runtime.CompilerServices.Unsafe => 0x5423e47b => 18
	i32 1460219004, ; 30: Xamarin.Forms.Xaml => 0x57092c7c => 42
	i32 1469204771, ; 31: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x57924923 => 21
	i32 1592978981, ; 32: System.Runtime.Serialization.dll => 0x5ef2ee25 => 2
	i32 1622152042, ; 33: Xamarin.AndroidX.Loader.dll => 0x60b0136a => 33
	i32 1639515021, ; 34: System.Net.Http.dll => 0x61b9038d => 1
	i32 1658251792, ; 35: Xamarin.Google.Android.Material.dll => 0x62d6ea10 => 43
	i32 1711441057, ; 36: SQLitePCLRaw.lib.e_sqlite3.android => 0x660284a1 => 12
	i32 1729485958, ; 37: Xamarin.AndroidX.CardView.dll => 0x6715dc86 => 23
	i32 1766324549, ; 38: Xamarin.AndroidX.SwipeRefreshLayout => 0x6947f945 => 36
	i32 1776026572, ; 39: System.Core.dll => 0x69dc03cc => 15
	i32 1788241197, ; 40: Xamarin.AndroidX.Fragment => 0x6a96652d => 28
	i32 1808609942, ; 41: Xamarin.AndroidX.Loader => 0x6bcd3296 => 33
	i32 1813201214, ; 42: Xamarin.Google.Android.Material => 0x6c13413e => 43
	i32 1867746548, ; 43: Xamarin.Essentials.dll => 0x6f538cf4 => 38
	i32 1878053835, ; 44: Xamarin.Forms.Xaml.dll => 0x6ff0d3cb => 42
	i32 2011961780, ; 45: System.Buffers.dll => 0x77ec19b4 => 14
	i32 2019465201, ; 46: Xamarin.AndroidX.Lifecycle.ViewModel => 0x785e97f1 => 32
	i32 2055257422, ; 47: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x7a80bd4e => 31
	i32 2067639960, ; 48: Menu_Desplegable.Android.dll => 0x7b3dae98 => 0
	i32 2097448633, ; 49: Xamarin.AndroidX.Legacy.Support.Core.UI => 0x7d0486b9 => 29
	i32 2103459038, ; 50: SQLitePCLRaw.provider.e_sqlite3.dll => 0x7d603cde => 13
	i32 2126786730, ; 51: Xamarin.Forms.Platform.Android => 0x7ec430aa => 40
	i32 2174586329, ; 52: Menu_Desplegable.Android => 0x819d8dd9 => 0
	i32 2201231467, ; 53: System.Net.Http => 0x8334206b => 1
	i32 2279755925, ; 54: Xamarin.AndroidX.RecyclerView.dll => 0x87e25095 => 34
	i32 2465273461, ; 55: SQLitePCLRaw.batteries_v2.dll => 0x92f11675 => 10
	i32 2475788418, ; 56: Java.Interop.dll => 0x93918882 => 4
	i32 2562349572, ; 57: Microsoft.CSharp => 0x98ba5a04 => 6
	i32 2732626843, ; 58: Xamarin.AndroidX.Activity => 0xa2e0939b => 20
	i32 2737747696, ; 59: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0xa32eb6f0 => 21
	i32 2766581644, ; 60: Xamarin.Forms.Core => 0xa4e6af8c => 39
	i32 2778768386, ; 61: Xamarin.AndroidX.ViewPager.dll => 0xa5a0a402 => 37
	i32 2810250172, ; 62: Xamarin.AndroidX.CoordinatorLayout.dll => 0xa78103bc => 24
	i32 2819470561, ; 63: System.Xml.dll => 0xa80db4e1 => 19
	i32 2853208004, ; 64: Xamarin.AndroidX.ViewPager => 0xaa107fc4 => 37
	i32 2905242038, ; 65: mscorlib.dll => 0xad2a79b6 => 8
	i32 2978675010, ; 66: Xamarin.AndroidX.DrawerLayout => 0xb18af942 => 27
	i32 3044182254, ; 67: FormsViewGroup => 0xb57288ee => 3
	i32 3111772706, ; 68: System.Runtime.Serialization => 0xb979e222 => 2
	i32 3247949154, ; 69: Mono.Security => 0xc197c562 => 47
	i32 3258312781, ; 70: Xamarin.AndroidX.CardView => 0xc235e84d => 23
	i32 3286872994, ; 71: SQLite-net.dll => 0xc3e9b3a2 => 9
	i32 3317135071, ; 72: Xamarin.AndroidX.CustomView.dll => 0xc5b776df => 26
	i32 3353484488, ; 73: Xamarin.AndroidX.Legacy.Support.Core.UI.dll => 0xc7e21cc8 => 29
	i32 3360279109, ; 74: SQLitePCLRaw.core => 0xc849ca45 => 11
	i32 3362522851, ; 75: Xamarin.AndroidX.Core => 0xc86c06e3 => 25
	i32 3366347497, ; 76: Java.Interop => 0xc8a662e9 => 4
	i32 3374999561, ; 77: Xamarin.AndroidX.RecyclerView => 0xc92a6809 => 34
	i32 3395150330, ; 78: System.Runtime.CompilerServices.Unsafe.dll => 0xca5de1fa => 18
	i32 3404865022, ; 79: System.ServiceModel.Internals => 0xcaf21dfe => 45
	i32 3429136800, ; 80: System.Xml => 0xcc6479a0 => 19
	i32 3476120550, ; 81: Mono.Android => 0xcf3163e6 => 7
	i32 3536029504, ; 82: Xamarin.Forms.Platform.Android.dll => 0xd2c38740 => 40
	i32 3632359727, ; 83: Xamarin.Forms.Platform => 0xd881692f => 41
	i32 3641597786, ; 84: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0xd90e5f5a => 31
	i32 3672681054, ; 85: Mono.Android.dll => 0xdae8aa5e => 7
	i32 3689375977, ; 86: System.Drawing.Common => 0xdbe768e9 => 46
	i32 3754567612, ; 87: SQLitePCLRaw.provider.e_sqlite3 => 0xdfca27bc => 13
	i32 3802020141, ; 88: Menu_Desplegable.dll => 0xe29e392d => 5
	i32 3829621856, ; 89: System.Numerics.dll => 0xe4436460 => 17
	i32 3876362041, ; 90: SQLite-net => 0xe70c9739 => 9
	i32 3896760992, ; 91: Xamarin.AndroidX.Core.dll => 0xe843daa0 => 25
	i32 3955647286, ; 92: Xamarin.AndroidX.AppCompat.dll => 0xebc66336 => 22
	i32 4105002889, ; 93: Mono.Security.dll => 0xf4ad5f89 => 47
	i32 4151237749, ; 94: System.Core => 0xf76edc75 => 15
	i32 4260525087 ; 95: System.Buffers => 0xfdf2741f => 14
], align 4
@assembly_image_cache_indices = local_unnamed_addr constant [96 x i32] [
	i32 44, i32 39, i32 36, i32 6, i32 20, i32 17, i32 30, i32 12, ; 0..7
	i32 38, i32 28, i32 8, i32 16, i32 26, i32 10, i32 46, i32 5, ; 8..15
	i32 44, i32 30, i32 3, i32 35, i32 22, i32 41, i32 32, i32 16, ; 16..23
	i32 11, i32 27, i32 45, i32 35, i32 24, i32 18, i32 42, i32 21, ; 24..31
	i32 2, i32 33, i32 1, i32 43, i32 12, i32 23, i32 36, i32 15, ; 32..39
	i32 28, i32 33, i32 43, i32 38, i32 42, i32 14, i32 32, i32 31, ; 40..47
	i32 0, i32 29, i32 13, i32 40, i32 0, i32 1, i32 34, i32 10, ; 48..55
	i32 4, i32 6, i32 20, i32 21, i32 39, i32 37, i32 24, i32 19, ; 56..63
	i32 37, i32 8, i32 27, i32 3, i32 2, i32 47, i32 23, i32 9, ; 64..71
	i32 26, i32 29, i32 11, i32 25, i32 4, i32 34, i32 18, i32 45, ; 72..79
	i32 19, i32 7, i32 40, i32 41, i32 31, i32 7, i32 46, i32 13, ; 80..87
	i32 5, i32 17, i32 9, i32 25, i32 22, i32 47, i32 15, i32 14 ; 96..95
], align 4

@marshal_methods_number_of_classes = local_unnamed_addr constant i32 0, align 4

; marshal_methods_class_cache
@marshal_methods_class_cache = global [0 x %struct.MarshalMethodsManagedClass] [
], align 4; end of 'marshal_methods_class_cache' array


@get_function_pointer = internal unnamed_addr global void (i32, i32, i32, i8**)* null, align 4

; Function attributes: "frame-pointer"="all" "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" "target-cpu"="generic" "target-features"="+armv7-a,+d32,+dsp,+fp64,+neon,+thumb-mode,+vfp2,+vfp2sp,+vfp3,+vfp3d16,+vfp3d16sp,+vfp3sp,-aes,-fp-armv8,-fp-armv8d16,-fp-armv8d16sp,-fp-armv8sp,-fp16,-fp16fml,-fullfp16,-sha2,-vfp4,-vfp4d16,-vfp4d16sp,-vfp4sp" uwtable willreturn writeonly
define void @xamarin_app_init (void (i32, i32, i32, i8**)* %fn) local_unnamed_addr #0
{
	store void (i32, i32, i32, i8**)* %fn, void (i32, i32, i32, i8**)** @get_function_pointer, align 4
	ret void
}

; Names of classes in which marshal methods reside
@mm_class_names = local_unnamed_addr constant [0 x i8*] zeroinitializer, align 4
@__MarshalMethodName_name.0 = internal constant [1 x i8] c"\00", align 1

; mm_method_names
@mm_method_names = local_unnamed_addr constant [1 x %struct.MarshalMethodName] [
	; 0
	%struct.MarshalMethodName {
		i64 0, ; id 0x0; name: 
		i8* getelementptr inbounds ([1 x i8], [1 x i8]* @__MarshalMethodName_name.0, i32 0, i32 0); name
	}
], align 8; end of 'mm_method_names' array


attributes #0 = { "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable willreturn writeonly "frame-pointer"="all" "target-cpu"="generic" "target-features"="+armv7-a,+d32,+dsp,+fp64,+neon,+thumb-mode,+vfp2,+vfp2sp,+vfp3,+vfp3d16,+vfp3d16sp,+vfp3sp,-aes,-fp-armv8,-fp-armv8d16,-fp-armv8d16sp,-fp-armv8sp,-fp16,-fp16fml,-fullfp16,-sha2,-vfp4,-vfp4d16,-vfp4d16sp,-vfp4sp" }
attributes #1 = { "min-legal-vector-width"="0" mustprogress "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable "frame-pointer"="all" "target-cpu"="generic" "target-features"="+armv7-a,+d32,+dsp,+fp64,+neon,+thumb-mode,+vfp2,+vfp2sp,+vfp3,+vfp3d16,+vfp3d16sp,+vfp3sp,-aes,-fp-armv8,-fp-armv8d16,-fp-armv8d16sp,-fp-armv8sp,-fp16,-fp16fml,-fullfp16,-sha2,-vfp4,-vfp4d16,-vfp4d16sp,-vfp4sp" }
attributes #2 = { nounwind }

!llvm.module.flags = !{!0, !1, !2}
!llvm.ident = !{!3}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!2 = !{i32 1, !"min_enum_size", i32 4}
!3 = !{!"Xamarin.Android remotes/origin/d17-5 @ 45b0e144f73b2c8747d8b5ec8cbd3b55beca67f0"}
!llvm.linker.options = !{}
