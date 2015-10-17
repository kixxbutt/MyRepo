uniform sampler2D tex;
uniform float SPower;
uniform float FPower;
uniform vec3 Ka;
uniform vec3 LightColor;
uniform vec3 Ks;
uniform vec4 DiffuseColor;
uniform vec4 FresnelColor;
varying vec3 N;
varying vec3 L;
varying vec3 V;


void main()
{
	// Diffuse
	float NdotL = max( dot( N, L ), 0.0);
	vec3 Kd = vec3( NdotL );
	
	// Specular blinn
	vec3 H = normalize( L + V );
	float NdotH = max( dot( N, H ), 0.0 );
	float SpecPow = pow( NdotH, SPower );
	vec3 Ks = Ks * SpecPow;

	// Fresnel
	float NdotV = max( 1.0 - dot( N, V ), 0.0 ); // 1.0 - dot is to invert the value range
	float FresPow = pow( NdotV, FPower );
	vec3 Fresnel = FresnelColor.rgb * FresPow * FresnelColor.a;

	vec4 pixel = texture2D( tex, gl_TexCoord[0].xy );

	gl_FragColor = vec4( pixel.rgb * DiffuseColor.rgb *  Kd + Ks + Fresnel + Ka, DiffuseColor.a * pixel.a);

	//gl_FragColor = vec4( DiffuseColor.rgb * pixel.rgb * Kd + Ks + Fresnel, pixel.a * DiffuseColor.a);

	//gl_FragColor = vec4(NdotL, NdotL, NdotL, 1.0);
	
	//vec4 color = texture2D( tex, gl_TexCoord[0].xy )

	//vec2 pixelVec = gl_TexCoord[0].xy - vec2(0.0, 0.0);

	//vec4 color = texture2D( tex, gl_TexCoord[0].xy );

	//float pixelDis = normalize( length( pixelVec ) );

	//gl_FragColor = vec4( 1.0, 0.0, 0.0, pixelDis );

	//gl_FragColor = color;


}