def anagram()
    hashTable = {}
    
    File.new('../test/words_test', 'r').each_line do |word|
        key = word.chomp.split('').sort
        
        if hashTable[key]
            hashTable[key] = hashTable[key] + ', ' + word.chomp
        else
            hashTable[key] = word.chomp
        end
    end
    
    hashTable.keys.each { |k| puts hashTable[k]}
end

anagram()
