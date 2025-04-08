import { Modifications } from "./Classes/Modifications"


/**
    @param {string} inputFieldId - The Id of the input files
    @returns {boolean}
 */
function IsThereFiles(inputFieldId) {
    return document.getElementById(inputFieldId).files.length > 0
}

/**
 * Change the content of the target element if there is one or more files in the input
    @param {string} inputFieldId - The Id of the input files
    @param {string} targetId - The Id of the element which will be altered
    @param {?Modifications[]} modifications -  
    @returns {void}

*/
function IsThereFilesWithTarget(inputFieldId, targetId, modifications) {

}