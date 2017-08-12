/**
 * @license Copyright (c) 2003-2017, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see LICENSE.md or http://ckeditor.com/license
 */

CKEDITOR.editorConfig = function( config ) {
	// Define changes to default configuration here. For example:
	// config.language = 'fr';
	// config.uiColor = '#AADC6E';
    config.toolbar = [
     
        
        { name: 'basicstyles', items: ['Bold', 'Italic', 'Underline', 'Strike', 'Subscript', 'Superscript', '-', 'CopyFormatting', 'RemoveFormat'] },
        { name: 'paragraph', items: ['NumberedList', 'BulletedList', '-', 'Outdent', 'Indent', '-', 'Blockquote', 'CreateDiv', '-', 'JustifyLeft', 'JustifyCenter', 'JustifyRight', 'JustifyBlock', '-', 'BidiLtr', 'BidiRtl', 'Language'] },
        { name: 'links', items: ['Link', 'Unlink', 'Anchor'] },
        { name: 'insert', items: ['Table', 'HorizontalRule', 'Smiley', 'SpecialChar', 'PageBreak', 'Iframe'] },
        //{ name: 'document', groups: ['mode', 'document', 'doctools'] },
       
        { name: 'tools', items: ['Maximize', 'ShowBlocks', 'Source', 'Preview','AddLayout'] },
       
    ];
    config.extraPlugins = 'basewidget,layoutmanager,image2,preview';
    //config.extraPlugins = "layoutmanager";
    //config.extraPlugins= 'image2';
    config.layoutmanager_loadbootstrap = true;
    config.layoutmanager_allowedContent;
    config.layoutmanager_buttonboxWidth = 58;

    CKEDITOR.config.height = 480;
    //config.extraPlugins = 'layoutmanager';
    //config.image2_alignClasses = ['image-left', 'image-center', 'image-right'];
    //config.image2_captionedClass = 'image-captioned';

};
