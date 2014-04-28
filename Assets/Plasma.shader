// Upgrade NOTE: replaced 'samplerRECT' with 'sampler2D'
Shader "Effects/Plasma" { 
Properties { 
   _MainTex ("Base (RGB)", RECT) = "white" {} 
   _ColorBand ("Base (RGB)", 2D) = "white" {} 
}
SubShader { 
ZTest Always Cull Off ZWrite Off 
      Fog { Mode off } 
   Pass { 
       
             
CGPROGRAM 
#pragma vertex vert_img 
#pragma fragment fragSh 
#pragma fragmentoption ARB_precision_hint_fastest 
#include "UnityCG.cginc"
uniform sampler2D _MainTex; 
uniform sampler2D _ColorBand;
float4 fragSh (v2f_img i) : COLOR 
{ 
    
   float2 ca = float2(0.2, 0.2); 
   float2 cb = float2(0.7, 0.9); 
   float da = distance(i.uv, ca); 
   float db = distance(i.uv, cb); 
    
   float c1 = sin(da * _CosTime.y * 16 + _Time.x); 
   float c2 = cos(i.uv.x * 8 + _Time.z); 
   float c3 = cos(db * 14) + _CosTime.x;
   float p = (c1 + c2 + c3) / 3; 
    
   return tex2D(_ColorBand, float2(p, 0.5)); 
} 
ENDCG 
   } 
} 
Fallback off 
}