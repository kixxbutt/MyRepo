uniform sampler2D tex0;
uniform sampler2D tex1;
uniform sampler2D tex2;

varying vec3 T;
varying vec3 B;
varying vec3 N;

varying vec3 L;
varying vec3 V;

void main()
{
	vec4 colorTexture = texture2D( tex0, gl_TexCoord[0].xy );
	vec4 normalTexture = normalize( texture2D( tex1, gl_TexCoord[0].xy ) * 2.0 - 1.0);
	vec4 brickTexture = texture2D( tex1, gl_TexCoord[0].xy );

	vec3 Tn = T; vec3 Bn = B; vec3 Nn = N;

	vec3 NN = normalize( (normalTexture.z * Nn) + (normalTexture.x * Bn) + (normalTexture.y * Tn) );

	// Diffuse
	float NdotL = max( dot( N, L ), 0.0) / 2.0;
	vec4 Kd = gl_Color * colorTexture * vec4(NdotL, NdotL, NdotL, 1.0);
	//vec4 Kd = vec4(NdotL, NdotL, NdotL, 1.0);
	
	// Specular
	vec3 H = normalize( L + V );
	float NdotH = max( dot( NN, H ), 0.0);
	float SpecPow = pow( NdotH, 30.0 ) * 1.0;
	//SpecPow *= 1.0 - texture2D( tex, gl_TexCoord[0].xy ).a;
	vec4 Ks = vec4( SpecPow, SpecPow, SpecPow, 1.0);

	// Fresnel
	float NdotV = max( 1.0 - dot( N, V ), 0.0); // 1.0 - dot is to invert the value range
	float FresPow = pow( NdotV, 2.0 );
	vec4 Kf = vec4( FresPow, FresPow, FresPow, 1.0 );

	//gl_FragColor = Kd + (Kf * NdotL) + Ks;
	gl_FragColor = Kd + Ks;

	//gl_FragColor = vec4(NdotL, NdotL, NdotL, 1.0);// * texture2D(tex, gl_TexCoord[0].xy);
}