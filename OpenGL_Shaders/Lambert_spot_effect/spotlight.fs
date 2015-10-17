#version 120
uniform sampler2D tex;
uniform float time;
uniform float intensity;
uniform float focus = 0.5;
uniform float falloff = 0.5;


void main()
{
	vec4 texture = texture2D( tex, gl_TexCoord[0].xy );

	float d = distance( gl_TexCoord[0].xy, vec2( 0.5, 0.5 ) );

	float alpha = 1.0;

	if(d < falloff)
	{
		alpha = ( focus * focus ) * ( d * d );
	}

	//alpha = alpha * ( focus * focus ) * ( d * d );

	vec3 color = vec3(0.0, 0.0, 0.0);

	gl_FragColor = vec4( vec3(color), alpha );
}