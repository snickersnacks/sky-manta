//Water Metaball Shader effect by Rodrigo Fernandez Diaz-2013
//Visit http://codeartist.info/ for more!!
Shader "Custom/Metaballs" {
Properties {  
    _MainTex ("Texture", 2D) = "white" { }        
   
    _InnerValue ("InnerValue", Range(0.1,1)) = 0.1   
    _OuterValue ("OuterValue", Range(0.1,1)) = 0.5   
    _TransTresh ("TransparencyTreshold", Range(0,1)) = 0.2 
    _MetaballAlpha ("MetaballAlpha", Range(0,1)) = 0.5 
}
SubShader {
	Tags {"Queue" = "Transparent" }
    Pass {
    Blend SrcAlpha OneMinusSrcAlpha     
	CGPROGRAM
	#pragma vertex vert
	#pragma fragment frag	
	#include "UnityCG.cginc"	
	float4 _Color;
	sampler2D _MainTex;	
	float _InnerValue,_OuterValue,_TransTresh,_MetaballAlpha;
	struct v2f {
	    float4  pos : SV_POSITION;
	    float2  uv : TEXCOORD0;
	};	
	float4 _MainTex_ST;	
	
	v2f vert (appdata_base v){
	    v2f o;
	    o.pos = mul (UNITY_MATRIX_MVP, v.vertex);
	    o.uv = TRANSFORM_TEX (v.texcoord, _MainTex);
	    return o;
	}	
	
	half4 frag (v2f i) : COLOR{		
		half4 texcol,finalColor;
	    texcol = tex2D (_MainTex, i.uv); 		
		//finalColor=_Color*texcol;
		finalColor=texcol;
		if(finalColor.a>_TransTresh){
			finalColor.a=_MetaballAlpha;
			finalColor=floor((finalColor/_InnerValue)*_OuterValue);
		}			
	    return finalColor;
	}
	ENDCG

    }
}
Fallback "VertexLit"
} 