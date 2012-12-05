function m
	dim editorName,editorValue,editorFieldId,cs,peopleCID,editorFieldName,recordName,bindJs,target,source,options
	editorName = cp.doc.getText( "editorName" )
	editorValue = cp.doc.getText( "editorValue" )
	editorFieldId = cp.doc.getInteger( "editorFieldId" )
	target = editorName & "-search"
	'
	if editorFieldid=0 Then
		lookupContentName = "people"
		'editorFieldName = editorName
		'pos=2
		'do while ( pos<len(editorFieldName)) and isNumeric( mid( editorFieldName, pos, 1 ))
		'	pos = pos + 1
		'loop
		'if pos<len( editorFieldName ) Then
		'	editorFieldName = mid( editorFieldName, pos )
		'	peopleCid = cp.content.getId( "people" )
		'	set cs = cp.csNew()
		'	if cs.openSql( "select id from ccfields where (name=" & cp.db.encodeSqlText(editorFieldName) & ")and(contentid=" & peopleCid & ")" ) Then
		'		editorFieldId = cs.getInteger( "id" )
		'	End If
		'	call cs.close()
		'end if
	end if
	recordName = cp.content.getRecordName( lookupContentName, editorValue )
	'
	source = "'http://jay3-selectsearch/selectSearchAutocomplete'"
	'source = "[{ label: 'Choice1', value: 'value1' },{ label: 'Choice2', value: 'value2' }]"
	options = "" _
		& "source:" & source _
		& ",response: function (event,ui){" _
			& vbcrlf & "alert('responseEvent:'+ui)" _
			& vbcrlf & "}" _
		& ""
	bindJs = "jQuery('#" & target & "').autocomplete({ " & options & " })"
	'bindJs = "jQuery('" & target & "').keyup(function(){alert('keyup')})"

	'
	m = "Search Select Editor"
	m = m & "<br>editorName=" & editorName
	m = m & "<br>editorValue=" & editorValue
	m = m & "<br>editorFieldId=" & editorFieldId
	m = m & "<br>lookupContentId=" & lookupContentId
	m = m & cp.html.hidden( editorName, editorValue, "a", "b" )
	'
	m = m & cp.html.inputtext( editorName, recordName,,,,,target )
	call cp.doc.addHeadJavascript( "jQuery(document).ready( function(){" & bindJs & "})" )
end function