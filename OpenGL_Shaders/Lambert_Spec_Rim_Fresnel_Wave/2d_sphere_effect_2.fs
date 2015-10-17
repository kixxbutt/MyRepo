uniform sampler2D tex;
uniform float time;

void main()
{

	//vec2 tc = gl_TexCoord[0].xy;

	//vec2 p = -1.0 + 2.0 * tc;

	//vec2 p =  tc;

	//float r = dot( p, p );

	//float r = tc.x;

	//if ( r > 1.0 ) discard;

	//float f = ( 1.0 - sqrt( 1.0 - r) ) / ( r );

	//float f = 2.0 - sqrt( 2.0 - r ) ;

	//float f = 1.0 - ( sqrt( r) ) ; // nice effect

	//vec2 uv;

	//uv.x = p.x * f + time;

	//uv.y = p.y * f + time;
	
	vec2 tc = -1.0 + 2.0 * gl_TexCoord[0].xy / vec2(1.0);

	//float r = sqrt( tc.x*tc.x + tc.y*tc.y );
	float r = dot(tc, tc);

	float f = ( 1.0 - sqrt( 1.0 - r ) ) / (r);

	vec2 uv;

	uv.x = tc.x * f + 0.5;
	uv.y = tc.y * f + 0.5;

	//if ( r > 1.0 ) discard;

	//gl_FragColor = vec4( f, 0.0, 0.0, 1.0 );

	gl_FragColor = vec4( texture2D( tex, uv ).xyz, 1.0);                                               

	//gl_FragColor = gl_Color * texture2D(tex, gl_TexCoord[0].xy);
}
