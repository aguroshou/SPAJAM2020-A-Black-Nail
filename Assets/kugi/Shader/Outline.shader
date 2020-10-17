Shader "Custom/Outline"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Scale ("Scale", Range(0, 1)) = 0
    }
    
    CGINCLUDE
    #include "UnityCG.cginc"
    
    float4 _Color;
    float _Scale;
    
    float4 frag(v2f_img i):SV_Target
    {
        float up = step(i.uv.y, _Scale/2);
        float down = step(1.0 - _Scale/2, i.uv.y);
        float right = step(i.uv.x, _Scale/2);
        float left = step(1.0 - _Scale/2, i.uv.x);
        return _Color * (up + down + left + right);
    }
    ENDCG
    
    SubShader
    {
        Tags {"Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent"}
        Blend SrcAlpha OneMinusSrcAlpha
        Pass
        {
            CGPROGRAM
            #pragma vertex vert_img
            #pragma fragment frag
            ENDCG
        }   
    }
}
