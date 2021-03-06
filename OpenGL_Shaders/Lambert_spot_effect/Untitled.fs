#version 120
uniform sampler2D tex;
uniform float SPower;
uniform float FPower;
uniform vec4 DiffuseColor;
uniform float time;
uniform float multiplier;
varying vec3 N;
varying vec3 L;
varying vec3 V;

void main()
{
	// Diffus
	//float NdotL = max( dot( N, L ), 0.0);
	//vec3 Kd = vec3( NdotL, NdotL, NdotL );
	
	// Specular
	//vec3 H = normalize( L + V );
	//float NdotH = max( dot( N, H ), 0.0);
	//float SpecPow = pow( NdotH, SPower );
	//vec3 Ks = vec3( SpecPow, SpecPow, SpecPow );

	// Fresnel
	//float NdotV = max( 1.0 - dot( N, V ), 0.0); // 1.0 - dot is to invert the value range
	//float FresPow = pow( NdotV, FPower );
	//vec3 Fresnel = vec3( FresPow, FresPow, FresPow );

	//vec3 lighting =  (Kd * Fresnel);
	//vec4 color = DiffuseColor * texture2D( tex, gl_TexCoord[0].xy );
	//vec3 finalcolor = color.rgb * lighting;

	//gl_FragColor = vec4( Fresnel.r, Fresnel.g, Fresnel.b, DiffuseColor.a);
	//gl_FragColor = vec4(NdotL, NdotL, NdotL, 1.0);

	vec4 texture = texture2D( tex, gl_TexCoord[0].xy );

	vec2 pixelVec= vec2( gl_TexCoord[0].xy) - vec2( 0.5, 0.5 );

	float pixelVecLength = -length( pixelVec ) * multiplier;

	vec4 color = vec4(1.0, 1.0, 1.0, 1.0) + pixelVecLength;

	gl_FragColor = vec4( vec3(color), 1.0 );

}