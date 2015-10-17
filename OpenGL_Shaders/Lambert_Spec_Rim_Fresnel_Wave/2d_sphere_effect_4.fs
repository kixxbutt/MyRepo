uniform sampler2D tex;
uniform float time;

void main()
{
	vec2 p = -1.0 + 2.0 * gl_TexCoord[0].xy;

	vec2 uv;

	float a = atan(p.y, p.x);

	float r = sqrt( dot( p,p ) );

	uv.x = (0.1/(r*r)) + time;

	uv.y = a / ( 3.1416 );

	vec3 col = texture2D( tex,uv ).xyz;

	gl_FragColor = vec4 (col,1.0);                                              

}
