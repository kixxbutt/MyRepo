uniform sampler2D tex;
uniform float time;

void main()
{
	//vec2 tc = -1.0 + 2.0 * gl_TexCoord[0].xy;
	vec2 tc = ( gl_TexCoord[0].xy ) ;

 	//tc = ( tc + 1.0 ) / 2.0;
	//	tc.y = -1. - 2. / tc.y;

	float r = dot( tc, tc );
	//float r = (tc.x * tc.x) + (tc.y * tc.y);

	//float f = (1.0 - sqrt((1.0 - r)*-1.))/r; invert
	float f = ( 1.0 - sqrt( ( 1.0 - r ) ) ) / r;

	//float f = ( 1.0 - sqrt( 1.0 - r )) / r;
	//float f = (1.0 - sqrt(1.0 - r)) / r;
	//float f = 1.0 - sqrt(1.0 - r);

	vec2 uv;

	uv.x = tc.x * f+time;// + 0.5;
	uv.y = tc.y * f;// + 0.5;

	//if ( r > 1.0 ) discard;

	//if ( r > 1.0 ) discard;

	gl_FragColor = vec4( texture2D( tex, uv ));

	//gl_FragColor = vec4( f, 0, 0, 1.0);
}
