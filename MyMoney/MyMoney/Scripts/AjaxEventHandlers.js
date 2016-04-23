function ajaxFailedFunc(ajaxContext)
{
    var response = ajaxContext.get_response;    
    alert("更新失敗，失敗原因：\n" + ajaxContext.responseJSON.join("\n"));
}