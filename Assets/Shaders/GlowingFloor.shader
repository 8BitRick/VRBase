// Shader created with Shader Forge v1.04 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.04;sub:START;pass:START;ps:flbk:,lico:1,lgpr:1,nrmq:1,limd:1,uamb:True,mssp:True,lmpd:False,lprd:False,rprd:False,enco:False,frtr:True,vitr:True,dbil:False,rmgx:True,rpth:0,hqsc:True,hqlp:False,tesm:0,blpr:0,bsrc:0,bdst:1,culm:0,dpts:2,wrdp:True,dith:2,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:3625,x:32755,y:32793,varname:node_3625,prsc:2|emission-1659-OUT;n:type:ShaderForge.SFN_TexCoord,id:3255,x:31292,y:31793,varname:node_3255,prsc:2,uv:0;n:type:ShaderForge.SFN_Multiply,id:8572,x:32310,y:31637,varname:node_8572,prsc:2|A-3255-U,B-5463-OUT;n:type:ShaderForge.SFN_Vector1,id:5463,x:32129,y:31685,varname:node_5463,prsc:2,v1:20;n:type:ShaderForge.SFN_Round,id:8083,x:32298,y:31470,varname:node_8083,prsc:2|IN-6194-OUT;n:type:ShaderForge.SFN_Abs,id:6048,x:32646,y:31457,varname:node_6048,prsc:2|IN-7767-OUT;n:type:ShaderForge.SFN_Subtract,id:7767,x:32476,y:31506,varname:node_7767,prsc:2|A-8083-OUT,B-6194-OUT;n:type:ShaderForge.SFN_Power,id:7369,x:32679,y:31631,varname:node_7369,prsc:2|VAL-2767-OUT,EXP-5310-OUT;n:type:ShaderForge.SFN_Vector1,id:5310,x:32490,y:31665,varname:node_5310,prsc:2,v1:8;n:type:ShaderForge.SFN_Subtract,id:2767,x:32866,y:31427,varname:node_2767,prsc:2|A-6048-OUT,B-4918-OUT;n:type:ShaderForge.SFN_Vector1,id:4918,x:32632,y:31355,varname:node_4918,prsc:2,v1:1;n:type:ShaderForge.SFN_Color,id:4278,x:32308,y:33115,ptovrint:False,ptlb:node_4278,ptin:_node_4278,varname:node_4278,prsc:2,glob:False,c1:0,c2:1,c3:0.08965492,c4:1;n:type:ShaderForge.SFN_Multiply,id:1659,x:32510,y:33063,varname:node_1659,prsc:2|A-6625-OUT,B-4278-RGB;n:type:ShaderForge.SFN_Multiply,id:6773,x:32262,y:32095,varname:node_6773,prsc:2|A-3255-V,B-6090-OUT;n:type:ShaderForge.SFN_Vector1,id:6090,x:32081,y:32143,varname:node_6090,prsc:2,v1:20;n:type:ShaderForge.SFN_Round,id:7783,x:32250,y:31928,varname:node_7783,prsc:2|IN-486-OUT;n:type:ShaderForge.SFN_Abs,id:8041,x:32598,y:31915,varname:node_8041,prsc:2|IN-4427-OUT;n:type:ShaderForge.SFN_Subtract,id:4427,x:32428,y:31964,varname:node_4427,prsc:2|A-7783-OUT,B-486-OUT;n:type:ShaderForge.SFN_Power,id:9200,x:32631,y:32089,varname:node_9200,prsc:2|VAL-6576-OUT,EXP-1587-OUT;n:type:ShaderForge.SFN_Vector1,id:1587,x:32442,y:32123,varname:node_1587,prsc:2,v1:8;n:type:ShaderForge.SFN_Subtract,id:6576,x:32818,y:31885,varname:node_6576,prsc:2|A-8041-OUT,B-757-OUT;n:type:ShaderForge.SFN_Vector1,id:757,x:32584,y:31813,varname:node_757,prsc:2,v1:1;n:type:ShaderForge.SFN_Max,id:4365,x:32129,y:32714,varname:node_4365,prsc:2|A-7369-OUT,B-9200-OUT;n:type:ShaderForge.SFN_Add,id:6194,x:32083,y:31381,varname:node_6194,prsc:2|A-8572-OUT,B-8120-OUT;n:type:ShaderForge.SFN_Vector1,id:8120,x:31907,y:31447,varname:node_8120,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Add,id:486,x:32053,y:31928,varname:node_486,prsc:2|A-6773-OUT,B-720-OUT;n:type:ShaderForge.SFN_Vector1,id:720,x:31877,y:31994,varname:node_720,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Multiply,id:150,x:32318,y:32802,varname:node_150,prsc:2|A-7800-OUT,B-1922-OUT;n:type:ShaderForge.SFN_Vector1,id:1922,x:32220,y:32628,varname:node_1922,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Time,id:7397,x:31354,y:32925,varname:node_7397,prsc:2;n:type:ShaderForge.SFN_Sin,id:9778,x:31570,y:32949,varname:node_9778,prsc:2|IN-7397-T;n:type:ShaderForge.SFN_Add,id:6900,x:31737,y:33060,varname:node_6900,prsc:2|A-9778-OUT,B-3180-OUT;n:type:ShaderForge.SFN_Vector1,id:3180,x:31471,y:33131,varname:node_3180,prsc:2,v1:1;n:type:ShaderForge.SFN_Multiply,id:1087,x:32010,y:33029,varname:node_1087,prsc:2|A-6900-OUT,B-9365-OUT;n:type:ShaderForge.SFN_Vector1,id:9365,x:31856,y:33132,varname:node_9365,prsc:2,v1:0.125;n:type:ShaderForge.SFN_Add,id:6625,x:32513,y:32758,varname:node_6625,prsc:2|A-150-OUT,B-1087-OUT;n:type:ShaderForge.SFN_Add,id:6457,x:32105,y:32432,varname:node_6457,prsc:2|A-7369-OUT,B-9200-OUT;n:type:ShaderForge.SFN_Vector1,id:5984,x:32226,y:32527,varname:node_5984,prsc:2,v1:1;n:type:ShaderForge.SFN_Min,id:7800,x:32312,y:32381,varname:node_7800,prsc:2|A-6457-OUT,B-5984-OUT;proporder:4278;pass:END;sub:END;*/

Shader "Shader Forge/GlowingFloor" {
    Properties {
        _node_4278 ("node_4278", Color) = (0,1,0.08965492,1)
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "ForwardBase"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma exclude_renderers xbox360 ps3 flash d3d11_9x 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform float4 _node_4278;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                return o;
            }
            fixed4 frag(VertexOutput i) : COLOR {
/////// Vectors:
////// Lighting:
////// Emissive:
                float node_6194 = ((i.uv0.r*20.0)+0.5);
                float node_7369 = pow((abs((round(node_6194)-node_6194))-1.0),8.0);
                float node_486 = ((i.uv0.g*20.0)+0.5);
                float node_9200 = pow((abs((round(node_486)-node_486))-1.0),8.0);
                float node_6457 = (node_7369+node_9200);
                float node_5984 = 1.0;
                float4 node_7397 = _Time + _TimeEditor;
                float3 emissive = (((min(node_6457,node_5984)*0.5)+((sin(node_7397.g)+1.0)*0.125))*_node_4278.rgb);
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
