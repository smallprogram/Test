function init_tinymce(textareasid) {
    tinymce.init({
        selector: textareasid,
        // 加载插件
        plugins: 'advlist anchor autolink autoresize autosave bbcode charmap code codesample colorpicker contextmenu directionality emoticons fullpage fullscreen help hr image imagetools insertdatetime legacyoutput link lists media nonbreaking noneditable pagebreak paste preview print quickbars save searchreplace spellchecker tabfocus table template textcolor textpattern toc visualblocks visualchars wordcount',
        // 工具栏设置
        toolbar: 'undo redo | bold italic underline strikethrough | fontselect fontsizeselect formatselect | alignleft aligncenter alignright alignjustify | outdent indent |  numlist bullist checklist | forecolor backcolor casechange permanentpen formatpainter removeformat | pagebreak | charmap emoticons | fullscreen  preview save print | insertfile image media pageembed template link anchor codesample | a11ycheck ltr rtl | showcomments addcomment',


        //contextmenu: 'link image table',


        // 手机模式下的设置
        mobile: {
            menubar: false,
            plugins: ['autosave', 'lists', 'autolink'],
            toolbar: ['undo', 'bold', 'italic', 'styleselect']
        },

        // 占位符
        placeholder: '请输入你要输入的信息......',

        // 是否展示tiny提供信息
        branding: false,
        // 语言
        language: 'zh_CN'
    })
}