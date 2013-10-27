require 'digest/md5'

def initBitmap(mapSize)
    array = Array.new
    mapSize.times do
        array.push 0
    end
    return array
end

def computeHashValue(word, startIndex, endIndex, mapSize)
    digest = Digest::MD5.hexdigest(word)
    return digest[startIndex, endIndex].to_i(16) % mapSize
end

def search(word, map)
    [1,2,3,4,5].each{ |i| return false if map[computeHashValue(word, i, i+5, map.size)] == 0 }
    return true 
end

def initBloomFilter(mapSize)
    bitmaps = initBitmap(mapSize)

    File.new('../test/words_test', 'r').each_line do |word|
       [1,2,3,4,5].each { |i| bitmaps[computeHashValue(word.chomp, i, i+5, mapSize)] = 1 } 
    end    

    return bitmaps
end

#map = initBloomFilter(50)
#puts search("xxx", map)
