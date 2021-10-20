import UrlHelper from '@Helpers/UrlHelper';

test('MakeLink_Empty', () => {
	const result = UrlHelper.makeLink('');

	expect(result, 'result').toBe('');
});

test('MakeLink_WithHttp', () => {
	const result = UrlHelper.makeLink('http://vocadb.net');

	expect(result, 'result').toBe('http://vocadb.net');
});

test('MakeLink_WithoutHttp', () => {
	const result = UrlHelper.makeLink('vocadb.net');

	expect(result, 'result').toBe('http://vocadb.net');
});

test('MakeLink_Mailto', () => {
	const result = UrlHelper.makeLink('mailto:miku@vocadb.net');

	expect(result, 'result').toBe('mailto:miku@vocadb.net');
});
